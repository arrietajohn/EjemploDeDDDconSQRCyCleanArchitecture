using FinanzasPersonales.Domain.Entities;

namespace FinanzasPersonales.Application.Contracts.Repositories.Writer;

public interface IReviewerWriteRepository<T> : IBaseDomainModelWriteRepository<T> where T : Reviewer
{
   
}
