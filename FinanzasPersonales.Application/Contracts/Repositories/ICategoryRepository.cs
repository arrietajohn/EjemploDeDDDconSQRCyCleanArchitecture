using FinanzasPersonales.Domain.Entities;

namespace FinanzasPersonales.Application.Contracts.Repositories;

public interface ICategoryRepository
{

    Task<bool> SaveAsync(Category category);
    Task<bool> UpdateAsync(Category category);
    Task<bool> DeleteAsync(Category category);
    Task<bool> DeleteAsync(int categoryId);
    Task<IEnumerable<Category>> GetAllAsync();
    Task<IEnumerable<Category>> GetByNameAsync(string name);
    Task<IEnumerable<Category>> GetByDescriptionAsync(string description);

    Task<Category> GetByid(int id);    
}
