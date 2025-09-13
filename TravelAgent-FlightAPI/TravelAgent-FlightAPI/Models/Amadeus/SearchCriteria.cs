using System.Text.Json.Serialization;

namespace TravelAgent_FlightAPI.Models.Amadeus;

public class SearchCriteria
{
    [JsonPropertyName("excludeAllotments")]
    public bool? ExcludeAllotments { get; set; }

    [JsonPropertyName("addOneWayOffers")]
    public bool? AddOneWayOffers { get; set; }

    [JsonPropertyName("maxFlightOffers")]
    public int? MaxFlightOffers { get; set; }

    [JsonPropertyName("maxPrice")]
    public int? MaxPrice { get; set; }

    [JsonPropertyName("allowAlternativeFareOptions")]
    public bool? AllowAlternativeFareOptions { get; set; }

    [JsonPropertyName("oneFlightOfferPerDay")]
    public bool? OneFlightOfferPerDay { get; set; }

    [JsonPropertyName("additionalInformation")]
    public AdditionalInformation AdditionalInformation { get; set; }

    [JsonPropertyName("pricingOptions")]
    public PricingOptions PricingOptions { get; set; }

    [JsonPropertyName("flightFilters")]
    public FlightFilters FlightFilters { get; set; }
}