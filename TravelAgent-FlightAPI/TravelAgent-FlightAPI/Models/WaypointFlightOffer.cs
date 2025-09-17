using System.Text.Json.Serialization;

namespace TravelAgent_FlightAPI.Models;

public class WaypointFlightOffer
{
    [JsonPropertyName("optionNumber")]
    public int OptionNumber { get; set; }

    [JsonPropertyName("roundTrip")]
    public List<WaypointItinerary> Itineraries { get; set; } = [];
    
    [JsonPropertyName("currency")]
    public string Currency { get; set; } = string.Empty;

    [JsonPropertyName("totalCost")]
    public decimal TotalCost { get; set; }

    [JsonPropertyName("travelClass")]
    public string TravelClass { get; set; } = string.Empty;

    [JsonPropertyName("remainingBookableSeats")]
    public int RemainingBookableSeats { get; set; }

    [JsonPropertyName("travellerType")]
    public string TravellerType{ get; set; } = string.Empty;
}

public class WaypointItinerary
{
    [JsonPropertyName("direction")]
    public string Direction { get; set; } = string.Empty;
    
    [JsonPropertyName("flights")]
    public List<WaypointSegment> Segments { get; set; } = [];
}

public class WaypointSegment
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("departure")]
    public WaypointFlightEndPoint Departure { get; set; } = new();

    [JsonPropertyName("arrival")]
    public WaypointFlightEndPoint Arrival { get; set; } = new();

    [JsonPropertyName("carrierCode")]
    public string CarrierCode { get; set; } = string.Empty;

    [JsonPropertyName("duration")]
    public string Duration { get; set; } = string.Empty;
}

public class WaypointFlightEndPoint
{
    [JsonPropertyName("airportCode")]
    public string AirportCode { get; set; } = string.Empty;
    
    [JsonPropertyName("terminal")]
    public string Terminal { get; set; } = string.Empty;

    [JsonPropertyName("at")]
    public DateTime? At { get; set; }
}