using System.Text.Json.Serialization;

namespace TravelAgent_FlightAPI.Models.Amadeus;

public class FlightSearchRequest
{
    [JsonPropertyName("currencyCode")]
    public string CurrencyCode { get; set; }

    [JsonPropertyName("originDestinations")]
    public List<OriginDestination> OriginDestinations { get; set; }

    [JsonPropertyName("travelers")]
    public List<Traveler> Travelers { get; set; }

    [JsonPropertyName("sources")]
    public List<string> Sources { get; set; }

    [JsonPropertyName("searchCriteria")]
    public SearchCriteria SearchCriteria { get; set; }
}