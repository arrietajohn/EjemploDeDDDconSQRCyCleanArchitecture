using FinanzasPersonales.Application.Contracts.Repositories.Reader;
using FinanzasPersonales.Domain.Entities;
using FinanzasPersonales.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FinanzasPersonales.Persistence.Repositories.Readers;

public class BaseDomainModelReaedRepositoty<T> : IBaseDomainModelReadRepository<T> where T : BaseDomainModel
{
    protected readonly EfDatabeseContext _efDatabeseContext;
    protected readonly ILogger<BaseDomainModelReaedRepositoty<T>> _logger;

    public BaseDomainModelReaedRepositoty(EfDatabeseContext efDatabeseContext, ILogger<BaseDomainModelReaedRepositoty<T>> logger)
    {
        _efDatabeseContext = efDatabeseContext;
        _logger = logger;
    }

    public async Task<IEnumerable<T>> FindAllAsync()
    {
        return await _efDatabeseContext.Set<T>().ToListAsync();
    }

    public async Task<IEnumerable<T>> FindByCreateDateAsync(DateTime createDate)
    {
        if(createDate == null )
        {
            throw new ArgumentException($"Find {GetType().Name} by CreateDate: The Date is Null ");
        } 
        
        if(createDate.Date > DateTime.Now.Date )
        {
            throw new Exception($"Find {GetType().Name} by CreateDate: is greater that {DateTime.Now.Date.ToString()} ");
        }

        IQueryable<T> list = from b in _efDatabeseContext.Set<T>()
                          where b.CreatedDate.Date == createDate.Date
                          select b;
       return  await list.ToListAsync();
    }

    public async Task<IEnumerable<T>> FindByCreateDateBetweenAsync(DateTime stardDate, DateTime endDate)
    {
        if (stardDate == null || endDate == null)
        {
            throw new ArgumentException($"Find {GetType().Name} by CreateDate: Start Date or End Date are null");
        }

        if (stardDate.Date > endDate.Date == null)
        {
            throw new ArgumentException($"Find {GetType().Name} by CreateDate: Start Date is greater than End Date");
        }
        IQueryable<T> list = from b in _efDatabeseContext.Set<T>()
                             where b.CreatedDate.Date >= stardDate.Date && b.CreatedDate.Date <= endDate.Date
                             select b;
        return await list.ToListAsync();
    }

    public async Task<T> FindByIdAsync(int id)
    {
        if (id == 0)
        {
            throw new Exception($"Find {GetType().Name} by Id: The ID cannot by zero");
        }
        return await  _efDatabeseContext.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> FindByModifiedDateAsync(DateTime modifiedDate)
    {
        if (modifiedDate == null)
        {
            throw new ArgumentException($"Find {GetType().Name} by ModifiedDate: The Date is Null ");
        }

        IQueryable<T> list = from b in _efDatabeseContext.Set<T>()
                             where b.ModifiedDate == modifiedDate
                             select b;
        return await list.ToListAsync();
    }

    public async Task<IEnumerable<T>> FindByModifiedDateBetweenAsync(DateTime stardDate, DateTime endDate)
    {
        if (stardDate == null || endDate == null)
        {
            throw new ArgumentException($"Find {GetType().Name} by ModifiedteDate: Start Date or End Date are null");
        }

        if (stardDate.Date > endDate.Date == null)
        {
            throw new ArgumentException($"Find {GetType().Name} by ModifiedteDate: Start Date is greater than End Date");
        }
        IQueryable<T> list = from b in _efDatabeseContext.Set<T>()
                             where b.ModifiedDate >= stardDate && b.CreatedDate <= endDate
                             select b;
        return await list.ToListAsync();
    }


    public Task<T> FindByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<T> FindByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

}
