using FinanzasPersonales.Domain.Entities;

namespace FinanzasPersonales.Application.Contracts.Repositories.Writer;

public interface CategoryWriteRepository<T> : IBaseDomainModelWriteRepository<T> where T : Category
{

    
}
