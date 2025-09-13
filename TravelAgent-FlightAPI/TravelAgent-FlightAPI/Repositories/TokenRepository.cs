using System.Net.Http.Headers;
using System.Text.Json;
using TravelAgent_FlightAPI.Models.Amadeus.Responses;
using TravelAgent_FlightAPI.Repositories.Interfaces;
using TravelAgent_FlightAPI.Utilities;

namespace TravelAgent_FlightAPI.Repositories;

public class TokenRepository(HttpClient httpClient) : ITokenRepository
{
    private readonly HttpClient _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    public async Task<AccessTokenResponse?> GetToken(string baseUrl)
    {
        if (string.IsNullOrEmpty(baseUrl)) throw new Exception("Unable to read AmadeusBaseUrl config value");
        
        var clientId = Environment.GetEnvironmentVariable(ConfigKeyNames.AmadeusApiKey);
        if (string.IsNullOrEmpty(clientId)) throw new Exception("Unable to read AmadeusApiKey config value");
        
        var clientSecret = Environment.GetEnvironmentVariable(ConfigKeyNames.AmadeusApiSecret);
        if (string.IsNullOrEmpty(clientSecret)) throw new Exception("Unable to read AmadeusApiSecret config value");
        
        var endpoint = $"https://{baseUrl}/v1/security/oauth2/token";
        
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint)
        {
            Content = new FormUrlEncodedContent(
            [
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("client_id", clientId),
                new KeyValuePair<string, string>("client_secret", clientSecret)
            ])
        };

        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
        
        try
        {
            using var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<AccessTokenResponse>(responseString);
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