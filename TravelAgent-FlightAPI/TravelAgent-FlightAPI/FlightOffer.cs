using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TravelAgent_FlightAPI;

public class FlightOffer(ILogger<FlightOffer> logger)
{
    [Function("GetFlightOffer")]
    public IActionResult GetFlightOffer([HttpTrigger(AuthorizationLevel.Function, "get", 
        Route = "flightOffer")] HttpRequest req)
    {
        logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome to Azure Functions!");
    }
    
    [Function("CreateFlightOffer")]
    public IActionResult CreateFlightOffer([HttpTrigger(AuthorizationLevel.Function, "post", 
        Route = "flightOffer")] HttpRequest req)
    {
        logger.LogError("CreateFlightOffer endpoint not implemented.");
        return new BadRequestObjectResult("Method not implemented");
    }

}