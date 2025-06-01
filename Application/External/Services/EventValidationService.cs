using Application.External.Interfaces;
using Application.External.Models;
using Application.External.Reponse;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Application.External.Services;

public class EventValidationService : IEventValidationService
{
    // Entire method made with help from chatgpt to bring in all the events, as there is no controller to
    // only get one event, to validate if the eventid sent is located among the events.

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

        // Uses propertynamecaseinsensitive to ignore the case of the incoming data and just make them into Eventpocos.
        var events = JsonSerializer.Deserialize<List<EventPoco>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        // Checking if null and checking if the id exists. Needs to turn the id to a string since I treat them as strings
        // and other person treats them as ints.
        if (events == null) { return ExternalResponse.Error("Something went wrong when trying to get the events for validation."); }
        if (!events.Any(e => e.Id.ToString() == eventId)) { return ExternalResponse.NotFound("Event with this id does not exist."); }

        return ExternalResponse.Ok();
    }
}
