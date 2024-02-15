using FinanzasPersonales.Application.Contracts.Repositories.Reader;
using FinanzasPersonales.Domain.Entities;
using FinanzasPersonales.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanzasPersonales.Persistence.Repositories.Readers;

public class CategoryReadRepository : ICategoryReadRepository<Category>
{
    private readonly EfDatabeseContext _efDatabeseContext;
    private readonly ILogger<CategoryReadRepository> _logger;

    public CategoryReadRepository(EfDatabeseContext efDatabeseContext, ILogger<CategoryReadRepository> logger)
    {
        _efDatabeseContext = efDatabeseContext;
        _logger = logger;
    }

    public async Task<IEnumerable<Category>> FindAllAsync()
    {
        return await _efDatabeseContext.Categories.ToListAsync();
    }

    public async Task<IEnumerable<Category>> FindByCreateDateAsync(DateTime createDate)
    {
        return await _efDatabeseContext.Categories.Where(c => c.CreatedDate.Date == createDate.Date).ToListAsync();
    }

    public async Task<IEnumerable<Category>> FindByCreateDateBetweenAsync(DateTime stardDate, DateTime endDate)
    {
        return await (from c in _efDatabeseContext.Categories
                      where c.CreatedDate.Date >= stardDate && c.CreatedDate <= endDate
                      select c ).ToListAsync();
    }

    public async Task<Category> FindByIdAsync(int id)
    {
        var category = await _efDatabeseContext.Categories.FindAsync(id);
        if(category == null)
        {
            throw new Exception($"Categoria Id: {id} no existe");
        }
        return category;
    }

    public Task<Category> FindByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Category> FindByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Category>> FindByModifiedDateAsync(DateTime modifiedDate)
    {
       return await _efDatabeseContext.Categories
        .Where(c => c.ModifiedDate != null) // Filtra por ModifiedDate no nulo
        .Where(c => c.ModifiedDate.Value.Date == modifiedDate.Date) // Compara solo las fechas
        .ToListAsync();

    }

    public async Task<IEnumerable<Category>> FindByModifiedDateBetweenAsync(DateTime stardDate, DateTime endDate)
    {
        return await _efDatabeseContext.Categories
       .Where(c => c.ModifiedDate != null) // Filtra por ModifiedDate no nulo
       .Where(c => c.ModifiedDate.Value.Date >= stardDate.Date 
                && c.ModifiedDate.Value.Date <= endDate.Date) // Compara solo las fechas
       .ToListAsync();
    }

    public async Task<IEnumerable<Category>> GetByDescriptionAsync(string description)
    {
        return await _efDatabeseContext.Categories.Where(c => c.Description != null && c.Description.Contains(description)).ToListAsync();
    }

    public async Task<IEnumerable<Category>> GetByNameAsync(string name)
    {
        return await _efDatabeseContext.Categories.Where(c => c.Name.Contains(name)).ToListAsync();

    }
}
