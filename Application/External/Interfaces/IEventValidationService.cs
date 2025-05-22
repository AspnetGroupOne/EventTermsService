using Application.External.Reponse;

namespace Application.External.Interfaces
{
    public interface IEventValidationService
    {
        Task<ExternalResponse> EventExistance(string eventId);
    }
}