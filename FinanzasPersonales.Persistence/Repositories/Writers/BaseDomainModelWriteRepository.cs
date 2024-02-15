using FinanzasPersonales.Application.Contracts.Repositories.Writer;
using FinanzasPersonales.Domain.Entities;
using FinanzasPersonales.Persistence.Database;
using Microsoft.Extensions.Logging;

namespace FinanzasPersonales.Persistence.Repositories.Readers;

public  class BaseDomainModelWriteRepository<T> : IBaseDomainModelWriteRepository<T> where T : BaseDomainModel
{
    protected ILogger<BaseDomainModelWriteRepository<T>> _logger;
    protected EfDatabeseContext _efDatabeseContext;

    public BaseDomainModelWriteRepository(EfDatabeseContext efeDatabeseContext, ILogger<BaseDomainModelWriteRepository<T>> logger) 
    {
        _efDatabeseContext = efeDatabeseContext;
        _logger = logger;   
    }

    public Task DeleteAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteMassiveAsync(IEnumerable<T> entiies)
    {
        throw new NotImplementedException();
    }

    public Task SaveAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task SaveMassiveAsync(IEnumerable<T> entiies)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateMassiveAsync(IEnumerable<T> entiies)
    {
        throw new NotImplementedException();
    }
}
