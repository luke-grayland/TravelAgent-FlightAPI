using System.Text.Json.Serialization;

namespace TravelAgent_FlightAPI.Models.Amadeus;

public class DateTimeRange
{
    [JsonPropertyName("date")]
    public string Date { get; set; } // ISO 8601 YYYY-MM-DD

    [JsonPropertyName("time")]
    public string Time { get; set; } // hh:mm:ss

    [JsonPropertyName("dateWindow")]
    public string DateWindow { get; set; } // e.g. I3D, P2D, M1D

    [JsonPropertyName("timeWindow")]
    public string TimeWindow { get; set; } // e.g. 6H
}