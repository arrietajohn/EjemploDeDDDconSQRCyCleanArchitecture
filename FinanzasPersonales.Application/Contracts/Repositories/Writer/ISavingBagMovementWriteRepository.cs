using FinanzasPersonales.Domain.Entities;

namespace FinanzasPersonales.Application.Contracts.Repositories.Writer;

public interface ISavingBagMovementWriteRepositor<T> : IFinancialMovementWriteRepository<T> where T : SavingBagMovement
{
   
}
