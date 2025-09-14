namespace TravelAgent_FlightAPI.Services.Interfaces;

public interface IMemCacheService
{
    void SetAccessToken(string accessToken, int expiresIn);
    string GetAccessToken();
}