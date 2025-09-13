using System.Text.Json.Serialization;

namespace TravelAgent_FlightAPI.Models.Amadeus;

public class CabinRestriction
{
    [JsonPropertyName("cabin")]
    public string Cabin { get; set; } // e.g. ECONOMY, BUSINESS

    [JsonPropertyName("coverage")]
    public string Coverage { get; set; } // e.g. MOST_SEGMENTS

    [JsonPropertyName("originDestinationIds")]
    public List<string> OriginDestinationIds { get; set; }
}