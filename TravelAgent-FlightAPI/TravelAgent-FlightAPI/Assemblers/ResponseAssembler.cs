using TravelAgent_FlightAPI.Assemblers.Interfaces;
using TravelAgent_FlightAPI.Constants;
using TravelAgent_FlightAPI.Models;
using TravelAgent_FlightAPI.Utilities;

namespace TravelAgent_FlightAPI.Assemblers;

public class ResponseAssembler : IResponseAssembler
{
    public GetFlightOfferResponse AssembleResponse(FlightSearchResponse amadeusResponse)
    {
        var result = new GetFlightOfferResponse { FlightOffers = [] };

        if (amadeusResponse.FlightOffers.Count == 0) return result;
        
        var offerIndex = 0;
        foreach (var flightOffer in amadeusResponse.FlightOffers.OrderBy(x => int.Parse(x.Id)))
        {
            var waypointOffer = new WaypointFlightOffer();

            if (!decimal.TryParse(flightOffer?.Price.Total, out var totalCost))
            {
                totalCost = 0;
            }
            
            waypointOffer.OptionNumber = offerIndex + 1;
            waypointOffer.Currency = flightOffer?.Price.Currency ?? string.Empty;
            waypointOffer.TotalCost = totalCost;

            if (flightOffer == null) continue;
            
            var itineraryIndex = 0;
            foreach (var itinerary in flightOffer.Itineraries)
            {
                var waypointItinerary = new WaypointItinerary
                {
                    Direction = itineraryIndex == 0 ? FlightType.Outbound : FlightType.Inbound
                };

                foreach (var segment in itinerary.Segments)
                {
                    var waypointSegment = new WaypointSegment();
                    waypointSegment.Id = segment.Id;
                    waypointSegment.Departure.At = segment.Departure.At;
                    waypointSegment.Departure.Terminal = segment.Departure.Terminal;
                    waypointSegment.Departure.AirportCode = segment.Departure.IataCode;
                    waypointSegment.Arrival.At = segment.Arrival.At;
                    waypointSegment.Arrival.Terminal = segment.Arrival.Terminal;
                    waypointSegment.Arrival.AirportCode = segment.Arrival.IataCode;
                    waypointSegment.CarrierCode = segment.CarrierCode;
                    
                    try
                    {
                        waypointSegment.Duration = Iso8601DurationToTime.ToHourMinute(segment.Duration);
                    }
                    catch
                    {
                        waypointSegment.Duration = string.Empty;
                    }
                    
                    waypointItinerary.Segments.Add(waypointSegment);
                }
                
                waypointOffer.Itineraries.Add(waypointItinerary);
                itineraryIndex++;
            }
            
            waypointOffer.TravelClass = flightOffer?.TravelerPricings?
                .FirstOrDefault()?.FareDetailsBySegment[0]?.Cabin ?? string.Empty;
            
            waypointOffer.TravellerType = flightOffer?.TravelerPricings?
                .FirstOrDefault()?.TravelerType ?? string.Empty;
            
            waypointOffer.RemainingBookableSeats = flightOffer?.NumberOfBookableSeats ?? 1;
            waypointOffer.Currency = flightOffer?.Price.Currency ?? string.Empty;
            
            result.FlightOffers.Add(waypointOffer);
            offerIndex++;
        }
        
        return result;
    }
}