using Microsoft.Extensions.Caching.Memory;
using TravelAgent_FlightAPI.Services.Interfaces;

namespace TravelAgent_FlightAPI.Services;

public class MemCacheService(IMemoryCache cache) : IMemCacheService
{
    private const string AccessTokenKey = "AccessToken";
    
    public void SetAccessToken(string accessToken, int expiresIn)
    {
        //Adding 1 min expiry tolerance
        var expiresInPeriod = TimeSpan.FromSeconds(expiresIn).Subtract(TimeSpan.FromMinutes(1));
        
        cache.Set(AccessTokenKey, accessToken, new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = expiresInPeriod
        });
    }

    public string GetAccessToken()
    {
        if (cache.TryGetValue(AccessTokenKey, out string? value))
        {
            return value ?? string.Empty;
        }

        return string.Empty;
    }
}