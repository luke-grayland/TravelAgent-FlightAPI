using System.Text.Json.Serialization;

namespace TravelAgent_FlightAPI.Models.Amadeus;

public class CarrierRestrictions
{
    [JsonPropertyName("includedCarrierCodes")]
    public List<string> IncludedCarrierCodes { get; set; }

    [JsonPropertyName("excludedCarrierCodes")]
    public List<string> ExcludedCarrierCodes { get; set; }
}