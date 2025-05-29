using Application.External.Interfaces;
using Application.External.Models;
using Application.External.Reponse;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Application.External.Services;

public class EventValidationService : IEventValidationService
{
    // This service is made with help from chatgpt to validate that an event exists. 

    private readonly HttpClient _httpClient;
    private readonly string _apiUrl;

    public EventValidationService(HttpClient httpClient, IOptions<EventSettings> options)
    {
        _httpClient = httpClient;
        _apiUrl = options.Value.Url;
    }

    public async Task<ExternalResponse> EventExistance(string eventId)
    {
        var response = await _httpClient.GetAsync(_apiUrl);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var events = JsonSerializer.Deserialize<List<EventPoco>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        if (events == null) { return ExternalResponse.Error("Something went wrong when trying to get the events for validation."); }
        if (!events.Any(e => e.Id.ToString() == eventId)) { return ExternalResponse.NotFound("Event with this id does not exist."); }

        return ExternalResponse.Ok();
    }
}
