using Application.External.Interfaces;
using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TermsController(ITermsService service, IEventValidationService validationService) : ControllerBase
{
    private readonly ITermsService _service = service;
    private readonly IEventValidationService _validation = validationService;

    [HttpPost]
    public async Task<IActionResult> CreateTerms([FromBody] AddTermsForm addForm)
    {
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

        //var existanceCheck = await _validation.EventExistance(addForm.EventId);
        //if (!existanceCheck.Success) { return BadRequest("Event with this id does not exist."); }

        var result = await _service.AddTermsAsync(addForm);
        if (!result.Success) { return BadRequest(result); }

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTerms([FromBody] UpdateTermsForm updateForm)
    {
        if (!ModelState.IsValid) { return BadRequest(ModelState); }

        var result = await _service.UpdateTermsAsync(updateForm);
        if (!result.Success) { return BadRequest(result); }

        return Ok(result);
    }

    [HttpGet("{eventId}")]
    public async Task<IActionResult> GetTerms(string eventId)
    {
        if (eventId == null) { return BadRequest("EntityId is null."); }

        var result = await _service.GetTermsAsync(eventId);
        if (!result.Success) { return BadRequest(result); }

        return Ok(result);
    }

    [HttpDelete("{eventId}")]
    public async Task<IActionResult> DeleteTerms(string eventId)
    {
        if (eventId == null) { return BadRequest("EntityId is null."); }

        var result = await _service.DeleteTermsAsync(eventId);
        if (!result.Success) { return BadRequest(result); }

        return Ok(result);
    }
}
