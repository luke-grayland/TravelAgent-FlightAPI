using System.Text.Json.Serialization;

namespace TravelAgent_FlightAPI.Models.Amadeus;

public class PricingOptions
{
    [JsonPropertyName("includedCheckedBagsOnly")]
    public bool? IncludedCheckedBagsOnly { get; set; }

    [JsonPropertyName("refundableFare")]
    public bool? RefundableFare { get; set; }

    [JsonPropertyName("noRestrictionFare")]
    public bool? NoRestrictionFare { get; set; }

    [JsonPropertyName("noPenaltyFare")]
    public bool? NoPenaltyFare { get; set; }
}