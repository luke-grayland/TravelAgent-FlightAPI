using System.Text.Json.Serialization;

namespace TravelAgent_FlightAPI.Models;

public class FlightOffer
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;
    
    [JsonPropertyName("originAirportCode")]
    public string OriginAirportCode { get; set; } = string.Empty;
    
    [JsonPropertyName("destinationAirportCode")]
    public string DestinationAirportCode { get; set; }  = string.Empty;

    [JsonPropertyName("departureDate")]
    public DateTime DepartureDate { get; set; }
    
    [JsonPropertyName("arrivalDate")]
    public DateTime ArrivalDate { get; set; }
    
    [JsonPropertyName("travelClass")]
    public string TravelClass { get; set; } = string.Empty;

    [JsonPropertyName("numBookableSeats")]
    public int NumBookableSeats { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; } = string.Empty;

    [JsonPropertyName("totalCost")]
    public decimal TotalCost { get; set; }

    [JsonPropertyName("travellerType")]
    public string TravellerType{ get; set; } = string.Empty;

    [JsonPropertyName("carrierCode")]
    public string CarrierCode { get; set; } = string.Empty;

    [JsonPropertyName("aircraftCode")]
    public string AircraftCode { get; set; } = string.Empty;

    [JsonPropertyName("duration")]
    public string Duration { get; set; } = string.Empty;
}