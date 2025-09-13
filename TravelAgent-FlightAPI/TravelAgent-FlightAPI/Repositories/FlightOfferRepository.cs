using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using TravelAgent_FlightAPI.Repositories.Interfaces;

namespace TravelAgent_FlightAPI.Repositories;

public class FlightOfferRepository(HttpClient httpClient) : IFlightOfferRepository
{
    private readonly HttpClient _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    private readonly JsonSerializerOptions? _jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = false
    };

    public async Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest request, string accessToken)
    {
        var jsonContent = JsonSerializer.Serialize(request, _jsonOptions);
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken); 
        
        try
        {
            using var response = await _httpClient.PostAsync(endpoint, content);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<TResponse>(responseString, _jsonOptions);
            }

            switch ((int)response.StatusCode)
            {
                case 400:
                    throw new HttpRequestException("Bad request (400). Check your request payload.");
                case 401:
                    throw new HttpRequestException("Unauthorized (401). Check authentication/credentials.");
                case 403:
                    throw new HttpRequestException("Forbidden (403). You don’t have access.");
                case 404:
                    throw new HttpRequestException("Not found (404). Check the endpoint.");
                case 500:
                    throw new HttpRequestException("Server error (500). Try again later.");
                default:
                    throw new HttpRequestException(
                        $"Unexpected status code: {(int)response.StatusCode} {response.ReasonPhrase}"
                    );
            }
        }
        catch (TaskCanceledException ex)
        {
            throw new TimeoutException("The request timed out.", ex);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while calling the API.", ex);
        }
    }
}
