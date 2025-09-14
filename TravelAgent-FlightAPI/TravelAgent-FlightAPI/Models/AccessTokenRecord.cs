namespace TravelAgent_FlightAPI.Models;

public class AccessTokenRecord
{
    public string Token { get; set; } = string.Empty;

    public DateTime Expiry { get; set; }
}