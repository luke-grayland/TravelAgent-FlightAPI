using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelAgent_FlightAPI.Models;
using TravelAgent_FlightAPI.Processors.Interfaces;

namespace TravelAgent_FlightAPI;

public class FlightOfferEndpoints(ILogger<FlightOfferEndpoints> logger, IGetOfferProcessor getOfferProcessor)
{
    [Function("GetFlightOffer")]
    public async Task<IActionResult> GetFlightOffer([HttpTrigger(AuthorizationLevel.Function, "get", 
        Route = "flightOffer")] HttpRequest req)
    {
        try
        {
            using var reader = new StreamReader(req.Body);
            var requestBody = reader.ReadToEnd();
            logger.LogInformation($"Request received: {requestBody}");

            var result = await getOfferProcessor.Process(requestBody);

            if (result.IsSuccess)
            {
                return new OkObjectResult("Done");
            }

            return new ObjectResult(result.ErrorMessage) { StatusCode = 400 };
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return new ObjectResult("Something went wrong!") {StatusCode = 500 };
        }
    }
    
    [Function("CreateFlightOffer")]
    public IActionResult CreateFlightOffer([HttpTrigger(AuthorizationLevel.Function, "post", 
        Route = "flightOffer")] HttpRequest req)
    {
        logger.LogError("CreateFlightOffer endpoint not implemented.");
        return new BadRequestObjectResult("Method not implemented");
    }

}