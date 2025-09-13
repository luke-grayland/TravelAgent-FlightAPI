using System.Text.Json;
using TravelAgent_FlightAPI.Assemblers;
using TravelAgent_FlightAPI.Constants;
using TravelAgent_FlightAPI.Models;
using TravelAgent_FlightAPI.Models.Amadeus;
using TravelAgent_FlightAPI.Models.Amadeus.Responses;
using TravelAgent_FlightAPI.Processors.Interfaces;
using TravelAgent_FlightAPI.Repositories.Interfaces;
using TravelAgent_FlightAPI.Utilities;

namespace TravelAgent_FlightAPI.Processors;

public class GetOfferProcessor(IRequestAssembler requestAssembler, 
    IFlightOfferRepository flightOfferRepository) : IGetOfferProcessor
{
    public async Task<Result<FlightOffer>> Process(string rawRequestBody)
    {
        //Deserialise request
        if(string.IsNullOrEmpty(rawRequestBody)) 
            return Result<FlightOffer>.Failure("Request body empty");
        
        var request = JsonSerializer.Deserialize<GetFlightOfferRequest>(rawRequestBody);
        
        if (request == null)
            return Result<FlightOffer>.Failure("Unable to deserialise request body");
        
        //Validate request
        if (request.DepartureDate < DateTime.UtcNow)
            return Result<FlightOffer>.Failure("Departure Date cannot be in the past");

        if (request.ReturnDate < request.DepartureDate)
            return Result<FlightOffer>.Failure("Return Date cannot be before Departure Date");
        
        if(!TravelClass.All.Contains(request.TravelClass))
            return Result<FlightOffer>.Failure("Invalid Travel Class");

        //Assemble Amadeus request
        var amadeusOfferRequest = requestAssembler.AssembleFlightSearchRequest(request);

        //Obtain bearer token
        var accessToken = "csdc";
        
        //Send request to Amadeus
        var baseUrl = Environment.GetEnvironmentVariable(ConfigKeyNames.AmadeusBaseUrl);
        if (string.IsNullOrEmpty(baseUrl)) throw new Exception("Unable to read base URL config value");
        
        var flightSearchResponse = await flightOfferRepository
            .PostAsync<FlightSearchRequest, FlightSearchResponse>(baseUrl, amadeusOfferRequest, accessToken); 
        
        
        
        return Result<FlightOffer>.Success(new FlightOffer());
    }
}