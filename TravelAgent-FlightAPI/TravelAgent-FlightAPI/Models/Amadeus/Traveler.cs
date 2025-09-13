using System.Text.Json.Serialization;

namespace TravelAgent_FlightAPI.Models.Amadeus;

public class Traveler
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("travelerType")]
    public string TravelerType { get; set; } // ADULT, CHILD, etc.

    [JsonPropertyName("associatedAdultId")]
    public string AssociatedAdultId { get; set; }
}