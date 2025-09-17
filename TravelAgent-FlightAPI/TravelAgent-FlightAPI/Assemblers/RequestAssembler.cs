using TravelAgent_FlightAPI.Constants;
using TravelAgent_FlightAPI.Models;
using TravelAgent_FlightAPI.Models.Amadeus;

namespace TravelAgent_FlightAPI.Assemblers;

public class RequestAssembler : IRequestAssembler
{
    public FlightSearchRequest AssembleFlightSearchRequest(GetFlightOfferRequest request)
    {
        var result = new FlightSearchRequest();

        result.CurrencyCode = "GBP";

        result.OriginDestinations =
        [
            new OriginDestination
            {
                Id = "1",
                OriginLocationCode = request.OriginAirportCode,
                DestinationLocationCode = request.DestinationAirportCode,
                DepartureDateTimeRange = new DateTimeRange()
                {
                    Date = request.DepartureDate.Date.ToString("yyyy-MM-dd"),
                    Time = request.DepartureDate.ToString("HH:mm:ss")
                }
            },
            new OriginDestination
            {
                Id = "2",
                OriginLocationCode = request.DestinationAirportCode,
                DestinationLocationCode = request.OriginAirportCode,
                DepartureDateTimeRange = new DateTimeRange()
                {
                    Date = request.ReturnDate.Date.ToString("yyyy-MM-dd"),
                    Time = request.ReturnDate.ToString("HH:mm:ss")
                }
            }
        ];

        result.Travelers = [
            new Traveler()
            {
                Id = "1",
                TravelerType = TravelerType.Adult
            }
        ];

        result.Sources = ["GDS"];

        result.SearchCriteria = new SearchCriteria()
        {
            MaxFlightOffers = 3,
            FlightFilters = new FlightFilters()
            {
                CabinRestrictions =
                [
                    new CabinRestriction()
                    {
                        Cabin = request.TravelClass,
                        OriginDestinationIds = ["1"]
                    }
                ]
            }
        };
        
        return result;
    }
}