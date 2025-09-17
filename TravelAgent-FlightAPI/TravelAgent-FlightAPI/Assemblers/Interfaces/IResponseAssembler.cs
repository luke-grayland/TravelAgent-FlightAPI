using TravelAgent_FlightAPI.Models;

namespace TravelAgent_FlightAPI.Assemblers.Interfaces;

public interface IResponseAssembler
{
    GetFlightOfferResponse AssembleResponse(FlightSearchResponse amadeusResponse);
}