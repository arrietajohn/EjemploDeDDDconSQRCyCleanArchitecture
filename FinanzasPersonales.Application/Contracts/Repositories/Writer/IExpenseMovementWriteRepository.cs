using FinanzasPersonales.Domain.Entities;
using System.Linq.Expressions;

namespace FinanzasPersonales.Application.Contracts.Repositories.Writer;

public interface IExpenseMovementWriteRepository<T> : IFinancialMovementWriteRepository<T> where T : ExpenseMovement
{ 


}
