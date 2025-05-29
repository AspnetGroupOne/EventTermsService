using Application.External.Interfaces;
using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Extensions.Attributes;
using System.Runtime.CompilerServices;

namespace Presentation.Controllers;

[UseApiKey]
[Route("api/[controller]")]
[ApiController]
public class TermsController(ITermsService service, IEventValidationService validationService) : ControllerBase
{
    private readonly ITermsService _service = service;
    private readonly IEventValidationService _validation = validationService;

    [HttpPost]
    public async Task<IActionResult> CreateTerms(AddTermsForm addForm)
    {
        if (!ModelState.IsValid) {  return BadRequest(ModelState); }

        //var existanceCheck = await _validation.EventExistance(addForm.EventId);
        //if (!existanceCheck.Success) { return BadRequest("Event with this id does not exist."); }

        var result = await _service.AddTermsAsync(addForm);
        if (!result.Success) { return BadRequest(result); }

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTerms(UpdateTermsForm updateForm)
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
