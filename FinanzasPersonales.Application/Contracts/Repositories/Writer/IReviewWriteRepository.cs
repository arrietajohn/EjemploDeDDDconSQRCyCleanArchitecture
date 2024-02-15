using FinanzasPersonales.Domain.Entities;

namespace FinanzasPersonales.Application.Contracts.Repositories.Writer;

public interface IReviewWriteRepository<T> : IBaseDomainModelWriteRepository<T> where T : Review
{


  
}

