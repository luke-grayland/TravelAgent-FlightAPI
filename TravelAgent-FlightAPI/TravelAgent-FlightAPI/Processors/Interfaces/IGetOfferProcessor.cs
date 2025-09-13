using TravelAgent_FlightAPI.Models;

namespace TravelAgent_FlightAPI.Processors.Interfaces;

public interface IGetOfferProcessor
{
    Task<Result<FlightOffer>> Process(string request);
}