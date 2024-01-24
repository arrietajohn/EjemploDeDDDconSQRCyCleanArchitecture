using FinanzasPersonales.Domain.Entities;

namespace FinanzasPersonales.Application.Contracts.Repositories;

public interface ICategoryRepository
{

    Task<bool> SaveAsync(Category category);
    Task<bool> UpdateAsync(Category category);
    Task<bool> DeleteAsync(Category category);
    Task<bool> DeleteAsync(int categoryId);
    Task<IEnumerable<Category>> GetAll();
    Task<IEnumerable<Category>> GetByName(string name);
    Task<IEnumerable<Category>> GetByDescription(string description);

    Task<Category> GetByid(int id);    
}
