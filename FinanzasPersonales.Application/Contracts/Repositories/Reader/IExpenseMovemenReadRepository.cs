using FinanzasPersonales.Domain.Entities;

namespace FinanzasPersonales.Application.Contracts.Repositories.Reader;

public interface IExpenseMovemenReadRepository<T> : IFinancialMovementReadRepository<T> where T : ExpenseMovement
{
    public Task<IEnumerable<ExpenseMovement>> GetByCategoryAsync(int categoryId);
    public Task<IEnumerable<ExpenseMovement>> GetByCategoryAsync(Category category);
    public Task<IEnumerable<ExpenseMovement>> GetPriorityAsync(int priority);
    public Task<IEnumerable<ExpenseMovement>> GetByIncomeAsync(int incomeId);
    public Task<IEnumerable<ExpenseMovement>> GetByIncomeAsync(IncomeMovement income);
    public Task<IEnumerable<ExpenseMovement>> GetBySavingBagAsync(int savingBagId);
    public Task<IEnumerable<ExpenseMovement>> GetBySavingBagAsync(SavingBagMovement savingBag);
    public Task<IEnumerable<ExpenseMovement>> GetByUserAsync(User user);
    public Task<IEnumerable<ExpenseMovement>> GetByUserAsync(int userId);

}
