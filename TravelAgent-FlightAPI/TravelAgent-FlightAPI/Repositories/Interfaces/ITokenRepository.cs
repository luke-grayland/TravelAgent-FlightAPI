using TravelAgent_FlightAPI.Models.Amadeus.Responses;

namespace TravelAgent_FlightAPI.Repositories.Interfaces;

public interface ITokenRepository
{
    Task<AccessTokenResponse?> GetToken(string baseUrl);
}