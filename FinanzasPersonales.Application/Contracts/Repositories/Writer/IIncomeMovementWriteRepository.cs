using FinanzasPersonales.Domain.Entities;

namespace FinanzasPersonales.Application.Contracts.Repositories.Writer;

public interface IIncomeMovementWriteRepository<T> : IFinancialMovementWriteRepository<T> where T : IncomeMovement
{

   


}
