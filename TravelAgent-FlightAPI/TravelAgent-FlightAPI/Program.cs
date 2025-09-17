using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TravelAgent_FlightAPI.Assemblers;
using TravelAgent_FlightAPI.Assemblers.Interfaces;
using TravelAgent_FlightAPI.Processors;
using TravelAgent_FlightAPI.Processors.Interfaces;
using TravelAgent_FlightAPI.Repositories;
using TravelAgent_FlightAPI.Repositories.Interfaces;
using TravelAgent_FlightAPI.Services;
using TravelAgent_FlightAPI.Services.Interfaces;

var builder = FunctionsApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddMemoryCache();

builder.Services.AddScoped<IGetOfferProcessor, GetOfferProcessor>();
builder.Services.AddScoped<IRequestAssembler, RequestAssembler>();
builder.Services.AddScoped<IFlightOfferRepository, FlightOfferRepository>();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();
builder.Services.AddScoped<IResponseAssembler, ResponseAssembler>();
builder.Services.AddScoped<IMemCacheService, MemCacheService>();

builder.ConfigureFunctionsWebApplication();

// Application Insights isn't enabled by default. See https://aka.ms/AAt8mw4.
// builder.Services
//     .AddApplicationInsightsTelemetryWorkerService()
//     .ConfigureFunctionsApplicationInsights();

builder.Build().Run();