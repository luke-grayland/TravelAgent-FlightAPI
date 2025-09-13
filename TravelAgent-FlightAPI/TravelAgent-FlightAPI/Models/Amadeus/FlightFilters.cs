using System.Text.Json.Serialization;

namespace TravelAgent_FlightAPI.Models.Amadeus;

public class FlightFilters
{
    [JsonPropertyName("crossBorderAllowed")]
    public bool? CrossBorderAllowed { get; set; }

    [JsonPropertyName("moreOvernightsAllowed")]
    public bool? MoreOvernightsAllowed { get; set; }

    [JsonPropertyName("returnToDepartureAirport")]
    public bool? ReturnToDepartureAirport { get; set; }

    [JsonPropertyName("railSegmentAllowed")]
    public bool? RailSegmentAllowed { get; set; }

    [JsonPropertyName("busSegmentAllowed")]
    public bool? BusSegmentAllowed { get; set; }

    [JsonPropertyName("maxFlightTime")]
    public int? MaxFlightTime { get; set; }

    [JsonPropertyName("carrierRestrictions")]
    public CarrierRestrictions CarrierRestrictions { get; set; }

    [JsonPropertyName("cabinRestrictions")]
    public List<CabinRestriction> CabinRestrictions { get; set; }

    [JsonPropertyName("connectionRestriction")]
    public ConnectionRestriction ConnectionRestriction { get; set; }
}