using FinanzasPersonales.Domain.Entities;
using System.Data;

namespace FinanzasPersonales.Application.Contracts.Repositories.Reader;

public interface ISourceReadRepository<T> : IBaseDomainModelReadRepository<T> where T : Source
{

    public Task<IEnumerable<Source>> GetByNameAsync(string name);
    public Task<IEnumerable<Source>> GetByDescripcionAsync(string descripcion);

}
