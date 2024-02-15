using FinanzasPersonales.Domain.Entities;

namespace FinanzasPersonales.Application.Contracts.Repositories.Writer;
public interface IBaseDomainModelWriteRepository<T> where T : BaseDomainModel
{
    public Task SaveAsync(T entity);
    public Task UpdateAsync(T entity);
    public Task DeleteAsync(T entity);
    public Task DeleteByIdAsync(int id);
    public Task DeleteByIdAsync(string id);
    public Task DeleteByIdAsync(Guid id);   
    public Task SaveMassiveAsync(IEnumerable<T> entiies);
    public Task DeleteMassiveAsync(IEnumerable<T> entiies);
    public Task UpdateMassiveAsync(IEnumerable<T> entiies);

}
