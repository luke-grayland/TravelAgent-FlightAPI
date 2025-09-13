namespace TravelAgent_FlightAPI.Repositories.Interfaces;

public interface IFlightOfferRepository
{
    Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest request, string accessToken);
}