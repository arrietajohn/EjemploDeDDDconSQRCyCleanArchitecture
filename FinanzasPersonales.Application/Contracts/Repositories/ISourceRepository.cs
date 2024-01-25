using FinanzasPersonales.Domain.Entities;
using System.Data;

namespace FinanzasPersonales.Application.Contracts.Repositories;

public interface ISourceRepository
{

    public Task<bool> SaveAsync(Source soource);
    public Task<bool> DeleteAsync(int id);  
    public Task<bool> UpdateAsync(Source soource);
    public Task<Source> GetByIdAsync(int id);
    public Task<IEnumerable<Source>> GetByNameAsync(string name);
    public Task<IEnumerable<Source>> GetAllAsync();
    public Task<Source> GetByDescripcionAsync(string descripcion);

}
