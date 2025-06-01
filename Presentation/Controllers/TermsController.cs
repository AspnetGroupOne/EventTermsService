using Application.External.Interfaces;
using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using Presentation.Documentation_Swagger;
using Presentation.Extensions.Attributes;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace Presentation.Controllers;

[UseApiKey]
[Consumes("application/json")]
[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]
public class TermsController(ITermsService service, IEventValidationService validationService) : ControllerBase
{
    private readonly ITermsService _service = service;
    private readonly IEventValidationService _validation = validationService;

    [HttpPost]
    [SwaggerOperation(Summary = "Adds terms to an event.")]
    [SwaggerResponse(200, "Added terms to the specified event.")]
    [SwaggerResponse(400, "The AddTermsForm was either containing invalid or missing properties.")]
    [SwaggerRequestExample(typeof(AddTermsForm), typeof(AddTermsForm_Example))]
    public async Task<IActionResult> CreateTerms([FromBody] AddTermsForm addForm)
    {
        // This modelstate check is from chatgpt for error checking while trying to find the issues that i had during launch of this MS.
        if (!ModelState.IsValid) {
            var errors = ModelState
            .Where(ms => ms.Value?.Errors.Count > 0)
            .Select(kvp => new
            {
                Field = kvp.Key,
                Errors = kvp.Value!.Errors.Select(e => e.ErrorMessage).ToList()
            });

            return BadRequest(new
            {
                message = "Model validation failed.",
                errors
            });
        }

        // Only have this check when adding new. 
        var existanceCheck = await _validation.EventExistance(addForm.EventId);
        if (!existanceCheck.Success) { return BadRequest("Event with this id does not exist."); }

        var result = await _service.AddTermsAsync(addForm);
        if (!result.Success) { return BadRequest(result); }

        return Ok(result);
    }

    [HttpPut]
    [SwaggerOperation(Summary = "Updates terms of a specified event.")]
    [SwaggerResponse(200, "Updated the terms of the specified event.")]
    [SwaggerResponse(400, "The UpdateTermsForm was either containing invalid or missing properties.")]
    [SwaggerRequestExample(typeof(UpdateTermsForm), typeof(UpdateTermsForm_Example))]
    public async Task<IActionResult> UpdateTerms([FromBody] UpdateTermsForm updateForm)
    {
        if (!ModelState.IsValid) { return BadRequest(ModelState); }

        var result = await _service.UpdateTermsAsync(updateForm);
        if (!result.Success) { return BadRequest(result); }

        return Ok(result);
    }

    [HttpGet("{eventId}")]
    [SwaggerOperation(Summary = "Updates terms of a specified event.")]
    [SwaggerResponse(200, "Gets the terms of the specified event.")]
    [SwaggerResponse(400, "The eventid was null.")]
    public async Task<IActionResult> GetTerms(string eventId)
    {
        if (eventId == null) { return BadRequest("EntityId is null."); }

        var result = await _service.GetTermsAsync(eventId);
        if (!result.Success) { return BadRequest(result); }

        return Ok(result);
    }

    [HttpDelete("{eventId}")]
    [SwaggerOperation(Summary = "Updates terms of a specified event.")]
    [SwaggerResponse(200, "Deleted the terms of the specified event.")]
    [SwaggerResponse(400, "The eventid was null.")]
    public async Task<IActionResult> DeleteTerms(string eventId)
    {
        if (eventId == null) { return BadRequest("EntityId is null."); }

        var result = await _service.DeleteTermsAsync(eventId);
        if (!result.Success) { return BadRequest(result); }

        return Ok(result);
    }
}
