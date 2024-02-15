using FinanzasPersonales.Domain.Entities;

namespace FinanzasPersonales.Application.Contracts.Repositories.Reader;

public interface ICategoryReadRepository<T> : IBaseDomainModelReadRepository<T> where T : Category
{
    Task<IEnumerable<Category>> GetByNameAsync(string name);
    Task<IEnumerable<Category>> GetByDescriptionAsync(string description);
}
