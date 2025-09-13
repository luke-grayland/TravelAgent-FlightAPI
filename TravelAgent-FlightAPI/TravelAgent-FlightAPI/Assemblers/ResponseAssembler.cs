using TravelAgent_FlightAPI.Constants;
using TravelAgent_FlightAPI.Models;

namespace TravelAgent_FlightAPI.Assemblers;

public class ResponseAssembler : IResponseAssembler
{
    public GetFlightOfferResponse AssembleResponse(FlightSearchResponse amadeusResponse)
    {
        var result = new GetFlightOfferResponse();
        result.FlightOffers = new List<FlightOffer>();

        if (amadeusResponse.FlightOffers.Count == 0) return result;
        
        var offerIndex = 0;
        foreach (var flightOffer in amadeusResponse.FlightOffers.OrderBy(x => int.Parse(x.Id)))
        {
            var offer = new FlightOffer();
            var segment = flightOffer.Itineraries[offerIndex].Segments[0];

            if (!decimal.TryParse(flightOffer?.Price.Total, out var totalCost))
            {
                totalCost = 0;
            }
            
            offer.OriginAirportCode = segment.Departure.IataCode;
            offer.DestinationAirportCode = segment.Arrival.IataCode;
            offer.DepartureDate = segment.Departure.At;
            offer.ArrivalDate = segment.Arrival.At;
            offer.TravelClass = flightOffer?.TravelerPricings?.FirstOrDefault()?.FareDetailsBySegment[0]?.Cabin ?? string.Empty;
            offer.NumBookableSeats = flightOffer?.NumberOfBookableSeats ?? 1;
            offer.Currency = flightOffer?.Price.Currency ?? string.Empty;
            offer.TotalCost = totalCost;
            offer.TravellerType = flightOffer?.TravelerPricings?.FirstOrDefault()?.TravelerType ?? string.Empty;
            offer.CarrierCode = segment.CarrierCode;
            offer.AircraftCode = segment.Aircraft.Code;
            offer.Duration = segment.Duration;
            
            offer.Type = offerIndex == 0 ? FlightType.Outbound : FlightType.Inbound;
            offerIndex++;
        }
        
        return result;
    }
}