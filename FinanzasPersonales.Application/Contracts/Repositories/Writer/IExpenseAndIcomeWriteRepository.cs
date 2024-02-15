using FinanzasPersonales.Domain.Entities;

namespace FinanzasPersonales.Application.Contracts.Repositories.Writer;

public interface IExpenseAndIcomeWriteRepository<T> : IBaseDomainModelWriteRepository<T> where T : ExpenseAndIncome
{
  
}
