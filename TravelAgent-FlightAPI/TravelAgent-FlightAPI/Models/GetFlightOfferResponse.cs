using System.Text.Json.Serialization;

namespace TravelAgent_FlightAPI.Models;

public class GetFlightOfferResponse
{
    [JsonPropertyName("flightOffers")] 
    public List<WaypointFlightOffer> FlightOffers { get; set; } = [];
}