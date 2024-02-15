using FinanzasPersonales.Domain.Entities;

namespace FinanzasPersonales.Application.Contracts.Repositories.Writer;

public interface IReviewRequestRepository<T> : IBaseDomainModelWriteRepository<T> where T : ReviewRequest
{

  

}
