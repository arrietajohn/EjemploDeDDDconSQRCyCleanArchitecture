using FinanzasPersonales.Domain.Entities;

namespace FinanzasPersonales.Application.Contracts.Repositories.Writer;

public interface IFinancialMovementWriteRepository<T> : IBaseDomainModelWriteRepository<T> where T : FinancialMovement
{

}
