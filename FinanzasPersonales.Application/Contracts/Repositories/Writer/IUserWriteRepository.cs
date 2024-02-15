using FinanzasPersonales.Domain.Entities;

namespace FinanzasPersonales.Application.Contracts.Repositories.Writer;

public interface IUserWriteRepository<T> : IBaseDomainModelWriteRepository<T> where T : User
{
}
