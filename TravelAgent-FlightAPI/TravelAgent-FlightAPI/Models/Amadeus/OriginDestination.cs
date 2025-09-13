using System.Text.Json.Serialization;

namespace TravelAgent_FlightAPI.Models.Amadeus;

public class OriginDestination
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("originLocationCode")]
    public string OriginLocationCode { get; set; }

    [JsonPropertyName("destinationLocationCode")]
    public string DestinationLocationCode { get; set; }

    [JsonPropertyName("includedConnectionPoints")]
    public List<string> IncludedConnectionPoints { get; set; }

    [JsonPropertyName("excludedConnectionPoints")]
    public List<string> ExcludedConnectionPoints { get; set; }

    [JsonPropertyName("originRadius")]
    public int? OriginRadius { get; set; }

    [JsonPropertyName("alternativeOriginsCodes")]
    public List<string> AlternativeOriginsCodes { get; set; }

    [JsonPropertyName("destinationRadius")]
    public int? DestinationRadius { get; set; }

    [JsonPropertyName("alternativeDestinationsCodes")]
    public List<string> AlternativeDestinationsCodes { get; set; }

    [JsonPropertyName("departureDateTimeRange")]
    public DateTimeRange DepartureDateTimeRange { get; set; }

    [JsonPropertyName("arrivalDateTimeRange")]
    public DateTimeRange ArrivalDateTimeRange { get; set; }
}
