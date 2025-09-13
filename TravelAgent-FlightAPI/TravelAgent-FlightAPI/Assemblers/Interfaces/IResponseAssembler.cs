using TravelAgent_FlightAPI.Models;

namespace TravelAgent_FlightAPI.Assemblers;

public interface IResponseAssembler
{
    GetFlightOfferResponse AssembleResponse(FlightSearchResponse amadeusResponse);
}