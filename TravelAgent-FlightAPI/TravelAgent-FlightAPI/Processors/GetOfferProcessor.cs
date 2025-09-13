using System.Text.Json;
using TravelAgent_FlightAPI.Assemblers;
using TravelAgent_FlightAPI.Constants;
using TravelAgent_FlightAPI.Models;
using TravelAgent_FlightAPI.Models.Amadeus;
using TravelAgent_FlightAPI.Processors.Interfaces;
using TravelAgent_FlightAPI.Repositories.Interfaces;
using TravelAgent_FlightAPI.Utilities;

namespace TravelAgent_FlightAPI.Processors;

public class GetOfferProcessor(IRequestAssembler requestAssembler, IFlightOfferRepository flightOfferRepository, 
    ITokenRepository tokenRepository, IResponseAssembler responseAssembler) : IGetOfferProcessor
{
    public async Task<Result<GetFlightOfferResponse>> Process(string rawRequestBody)
    {
        //Deserialise request
        if(string.IsNullOrEmpty(rawRequestBody)) 
            return Result<GetFlightOfferResponse>.Failure("Request body empty");
        
        var request = JsonSerializer.Deserialize<GetFlightOfferRequest>(rawRequestBody);
        
        if (request == null)
            return Result<GetFlightOfferResponse>.Failure("Unable to deserialise request body");
        
        //Validate request
        if (request.DepartureDate < DateTime.UtcNow)
            return Result<GetFlightOfferResponse>.Failure("Departure Date cannot be in the past");

        if (request.ReturnDate < request.DepartureDate)
            return Result<GetFlightOfferResponse>.Failure("Return Date cannot be before Departure Date");
        
        if(!TravelClass.All.Contains(request.TravelClass))
            return Result<GetFlightOfferResponse>.Failure("Invalid Travel Class");

        //Assemble Amadeus request
        var amadeusOfferRequest = requestAssembler.AssembleFlightSearchRequest(request);

        //Obtain access token & send request
        var baseUrl = Environment.GetEnvironmentVariable(ConfigKeyNames.AmadeusBaseUrl);
        if (string.IsNullOrEmpty(baseUrl)) throw new Exception("Unable to read base URL config value");
        
        var accessTokenResponse = await tokenRepository.GetToken(baseUrl);
        if (string.IsNullOrEmpty(accessTokenResponse?.AccessToken)) throw new Exception("Unable to retrieve access token");
        
        var flightOfferEndpoint = $"https://{baseUrl}/v2/shopping/flight-offers";
        var flightSearchResponse = await flightOfferRepository
            .PostAsync<FlightSearchRequest, FlightSearchResponse>(flightOfferEndpoint, amadeusOfferRequest, accessTokenResponse.AccessToken); 
        
        //Handle response
        if(flightSearchResponse == null) throw new Exception("Unable to deserialise response from Amadeus");

        var response = responseAssembler.AssembleResponse(flightSearchResponse); 
        
        return Result<GetFlightOfferResponse>.Success(response);
    }
}