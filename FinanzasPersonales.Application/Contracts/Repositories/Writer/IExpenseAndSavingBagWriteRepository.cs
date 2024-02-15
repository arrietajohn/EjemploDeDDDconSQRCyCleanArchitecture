using FinanzasPersonales.Domain.Entities;

namespace FinanzasPersonales.Application.Contracts.Repositories.Writer;

public interface IExpenseAndSavingBagWriteRepository<T> : IBaseDomainModelWriteRepository<T> where T : ExpenseAndSavingBag
{

   
}
