using System.Text.Json.Serialization;

namespace TravelAgent_FlightAPI.Models.Amadeus;

public class ConnectionRestriction
{
    [JsonPropertyName("maxNumberOfConnections")]
    public int? MaxNumberOfConnections { get; set; }

    [JsonPropertyName("nonStopPreferred")]
    public bool? NonStopPreferred { get; set; }
}