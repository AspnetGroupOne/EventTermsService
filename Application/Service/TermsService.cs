using Application.Factory;
using Application.Interfaces;
using Application.Models;
using Application.Models.Response;
using System.Runtime.InteropServices;

namespace Application.Service;

public class TermsService(ITermsRepository repository) : ITermsService
{
    private readonly ITermsRepository _repository = repository;


    public async Task<ServiceResponse> AddTermsAsync(AddTermsForm addForm)
    {
        try
        {
            if (addForm == null) { return ServiceResponse.Error("AddForm is null."); }

            var entity = TermFactory.Create(addForm);
            if (entity == null) { return ServiceResponse.Error("Something went wrong in the factory with the addform."); }

            var result = await _repository.CreateTermsAsync(entity);
            if (!result.Success) { return ServiceResponse.Error(result.Message); }

            return ServiceResponse.Ok();
        }
        catch (Exception ex) { return ServiceResponse.Error(ex.Message); }
    }

    public async Task<ServiceResponse> UpdateTermsAsync(UpdateTermsForm updateForm)
    {
        try
        {
            if (updateForm == null) { return ServiceResponse.Error("Updateform is null."); }

            var entity = TermFactory.Create(updateForm);
            if (entity == null) { return ServiceResponse.Error("Something went wrong in the factory with the updateform."); }

            var result = await _repository.UpdateTermsAsync(entity);
            if (!result.Success) { return ServiceResponse.Error(result.Message); }

            return ServiceResponse.Ok();
        }
        catch (Exception ex) { return ServiceResponse.Error(ex.Message); }
    }

    public async Task<ServiceResponse<EventTerms>> GetTermsAsync(string eventId)
    {
        try
        {
            if (eventId == null) { return ServiceResponse<EventTerms>.Error("EventId is null. Cannot get this entity.", null); }

            var entity = await _repository.GetTermsAsync(e => e.EventId == eventId);
            if (entity.Content == null) { return ServiceResponse<EventTerms>.Error("Entity is null.", null); }

            var terms = TermFactory.Create(entity.Content);
            if (terms == null) { return ServiceResponse<EventTerms>.Error("Something went wrong in the termsfactory. Returned null.", null); }

            return ServiceResponse<EventTerms>.Ok(terms);
        }
        catch (Exception ex) { return ServiceResponse<EventTerms>.Error(ex.Message, null); }
    }

    public async Task<ServiceResponse> DeleteTermsAsync(string eventId)
    {
        try
        {
            if (eventId == null) { return ServiceResponse.Error("Cannot remove a null eventId."); }

            var entity = await _repository.GetTermsAsync(e => e.EventId == eventId);
            if (entity.Content == null) { return ServiceResponse.NotFound(entity.Message); }

            var result = await _repository.DeleteTermsAsync(entity.Content);

            return ServiceResponse.Ok();
        }
        catch (Exception ex) { return ServiceResponse.Error(ex.Message); }
    }
}
