using Application.Entity;
using Application.Models.Response;
using System.Linq.Expressions;

namespace Application.Interfaces
{
    public interface ITermsRepository
    {
        Task<RepositoryResponse> CreateTermsAsync(TermsEntity entity);
        Task<RepositoryResponse> DeleteTermsAsync(TermsEntity entity);
        Task<RepositoryResponse> ExistsTermsAsync(Expression<Func<TermsEntity, bool>> expression);
        Task<RepositoryResponse<TermsEntity>> GetTermsAsync(Expression<Func<TermsEntity, bool>> expression);
        Task<RepositoryResponse> UpdateTermsAsync(TermsEntity entity);
    }
}