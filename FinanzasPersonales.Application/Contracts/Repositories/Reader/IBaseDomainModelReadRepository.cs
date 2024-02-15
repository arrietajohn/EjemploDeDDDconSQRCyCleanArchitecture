using FinanzasPersonales.Domain.Entities;

namespace FinanzasPersonales.Application.Contracts.Repositories.Reader;

public interface IBaseDomainModelReadRepository<T> where T : BaseDomainModel
{
    Task<IEnumerable<T>> FindAllAsync(); 
    Task<T> FindByIdAsync(int Id);
    Task<T> FindByIdAsync(Guid id);
    Task<T> FindByIdAsync(string id);
    Task<IEnumerable<T>> FindByCreateDateAsync(DateTime createDate);
    Task<IEnumerable<T>> FindByModifiedDateAsync(DateTime modifiedDate);
    Task<IEnumerable<T>> FindByCreateDateBetweenAsync(DateTime stardDate, DateTime endDate);
    Task<IEnumerable<T>> FindByModifiedDateBetweenAsync(DateTime stardDate, DateTime endDate);

}
