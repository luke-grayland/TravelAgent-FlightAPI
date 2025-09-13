using System.Text.Json.Serialization;

namespace TravelAgent_FlightAPI.Models.Amadeus;

public class AdditionalInformation
{
    [JsonPropertyName("chargeableCheckedBags")]
    public bool? ChargeableCheckedBags { get; set; }

    [JsonPropertyName("brandedFares")]
    public bool? BrandedFares { get; set; }
}