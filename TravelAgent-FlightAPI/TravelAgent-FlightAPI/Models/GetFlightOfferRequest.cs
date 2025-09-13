using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TravelAgent_FlightAPI.Models;

public class GetFlightOfferRequest
{
    [Required]
    [JsonPropertyName("originAirportCode")]
    public string OriginAirportCode { get; set; } = string.Empty;
    
    [Required]
    [JsonPropertyName("destinationAirportCode")]
    public string DestinationAirportCode { get; set; }  = string.Empty;

    [Required]
    [JsonPropertyName("departureDate")]
    public DateTime DepartureDate { get; set; }
    
    [Required]
    [JsonPropertyName("returnDate")]
    public DateTime ReturnDate { get; set; }
    
    [Required]
    [JsonPropertyName("travelClass")]
    public string TravelClass { get; set; } = string.Empty;
}