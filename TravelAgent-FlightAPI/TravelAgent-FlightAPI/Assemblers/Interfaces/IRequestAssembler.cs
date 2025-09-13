using TravelAgent_FlightAPI.Models;
using TravelAgent_FlightAPI.Models.Amadeus;

namespace TravelAgent_FlightAPI.Assemblers;

public interface IRequestAssembler
{
    public FlightSearchRequest AssembleFlightSearchRequest(GetFlightOfferRequest request);
}