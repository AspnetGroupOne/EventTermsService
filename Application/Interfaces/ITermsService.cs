using Application.Models;
using Application.Models.Response;

namespace Application.Interfaces
{
    public interface ITermsService
    {
        Task<ServiceResponse> AddTermsAsync(AddTermsForm addForm);
        Task<ServiceResponse> DeleteTermsAsync(string eventId);
        Task<ServiceResponse<EventTerms>> GetTermsAsync(string eventId);
        Task<ServiceResponse> UpdateTermsAsync(UpdateTermsForm updateForm);
    }
}