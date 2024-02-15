using FinanzasPersonales.Application.Contracts.Repositories.Writer;
using FinanzasPersonales.Domain.Entities;
using FinanzasPersonales.Persistence.Database;
using FinanzasPersonales.Persistence.Repositories.Readers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FinanzasPersonales.Persistence.Repositories.Writers;

public class CategoryWriteRepository : CategoryWriteRepository<Category>
{
    private readonly ILogger<CategoryWriteRepository> _logger;
    private readonly EfDatabeseContext _efDatabeseContext;

    public CategoryWriteRepository(EfDatabeseContext efeDatabeseContext, ILogger<CategoryWriteRepository> logger)
    {
        _efDatabeseContext = efeDatabeseContext;
        _logger = logger;
    }

    public async Task DeleteAsync(Category category)
    {
        if (category == null)
        {
            throw new ArgumentNullException(nameof(category));
        }
        var categoryFinded = await _efDatabeseContext.Categories.FindAsync(category.Id);
        if (categoryFinded == null)
        {
            // aqui debe ir una Excepcion personalizada propia del dominio 
            // EntityNotFoundException
            throw new Exception($"Delete Catetegory: - ID: {category.Id} not exists");
        }
        _efDatabeseContext.Categories.Remove(categoryFinded);
        await _efDatabeseContext.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        if (id < 0)
        {
            throw new Exception($"Delete Category - ID cannot be less than or equal to zero ");
        }
        var categoryToDelete = new Category { Id = id };
        await DeleteAsync(categoryToDelete);
    }


    public async Task DeleteMassiveAsync(IEnumerable<Category> entities, bool bySql)
    {
        var ids = entities.Select(e => e.Id).ToList();
        var tableName = _efDatabeseContext.Model.FindEntityType(typeof(Category)).GetTableName();
        var primaryKeyColumnName = _efDatabeseContext.Model.FindEntityType(typeof(Category)).FindPrimaryKey().Properties.Single().Name;

        var parameters = string.Join(", ", Enumerable.Range(0, ids.Count).Select(i => $"@p{i}"));
        var sql = $"DELETE FROM {tableName} WHERE {primaryKeyColumnName} IN ({parameters})";

        await _efDatabeseContext.Database.ExecuteSqlRawAsync(sql, ids.Cast<object>().ToArray());
    }

    public async Task DeleteMassiveAsync(IEnumerable<Category> categories)
    {
        if (categories == null || !categories.Any())
        {
            throw new Exception($"Delete Massive Categoris:  The list Categories is Emty");
        }
        _efDatabeseContext.Categories.RemoveRange(categories);
        await _efDatabeseContext.SaveChangesAsync();
    }

    public async Task SaveAsync(Category category)
    {
        if (category == null)
        {
            throw new Exception("Create Category: The Category cannot by Null");
        }
        if (category.Id > 0)
        {
            var categoryInDb = _efDatabeseContext.Categories.FindAsync(category.Id);
            if (categoryInDb != null)
            {
                throw new Exception("Create Category: The Category is already exists");
            }
        }
        _efDatabeseContext.Categories.Add(category);
        await _efDatabeseContext.SaveChangesAsync();
    }

    public async Task SaveMassiveAsync(IEnumerable<Category> categories)
    {

        if (categories == null || !categories.Any())
        {
            throw new Exception($"Create Massive Categoris:  The list Categories is Emty");
        }
        await _efDatabeseContext.Categories.AddRangeAsync(categories);
        await _efDatabeseContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Category category)
    {
        if (category == null)
        {
            throw new Exception($"Update Update Category:  The  Category cannot by null");
        }

        if (category.Id <= 0)
        {
            throw new Exception($"Update Category - ID cannot be less than or equal to zero ");
        }

        var categoryInBd = await _efDatabeseContext.Categories.FindAsync(category.Id);
        if (categoryInBd == null)
        {
            throw new Exception($"Update Category - The Category cannot be null ");
        }
    }

    public async Task UpdateMassiveAsync(IEnumerable<Category> categories)
    {
        if (categories == null || !categories.Any())
        {
            throw new Exception($"Update Massive Categoris:  The list Categories is Emty");
        }
        Task task = Task.Run(() =>
        {
            for (int i = 0; i < categories.Count(); i++)
            {
                var category = categories.ElementAt(i);
                if (category == null)
                {
                    throw new Exception($"Update Masive Category - The Category at position {i} is null");
                }
                if (category.Id <= 0)
                {
                    throw new Exception($"Update Masive Category - The Category at position {i} does not have an Id");
                }
                var categoriaInDbContext = _efDatabeseContext.Categories.Local.Any(c => c.Id == category.Id);
                if (categoriaInDbContext == null)
                {
                    _efDatabeseContext.Attach(category);
                }
                _efDatabeseContext.Entry(category).State = EntityState.Modified;
            }
        });
        await task;

        await _efDatabeseContext.SaveChangesAsync();

    }
    public Task DeleteByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
