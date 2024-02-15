using FinanzasPersonales.Domain.Entities;

namespace FinanzasPersonales.Application.Contracts.Repositories.Reader;

public interface IIncomeMovementReadRepository<T> : IFinancialMovementReadRepository<T> where T : IncomeMovement
{

    public Task<IEnumerable<IncomeMovement>> GetByValueSavedAsync(decimal value);
    public Task<IEnumerable<IncomeMovement>> GetByValueSavedBetweenAsync(decimal value1, decimal value2);
    public Task<IEnumerable<IncomeMovement>> GetByBalanceValueAsync(decimal value);
    public Task<IEnumerable<IncomeMovement>> GetByBalanceValueAsync(decimal value1, decimal value2);
    public Task<IEnumerable<IncomeMovement>> GetMinValueSavedAsync(decimal value);
    public Task<IEnumerable<IncomeMovement>> GetMaxValueSavedAsync(decimal value);
    public Task<IEnumerable<IncomeMovement>> GetMinBalanceValueAsync(decimal value);
    public Task<IEnumerable<IncomeMovement>> GetMaxBalanceValueAsync(decimal value);
    public Task<IEnumerable<IncomeMovement>> GetBySourceAsync(Source source);
    public Task<IEnumerable<IncomeMovement>> GetBySourceAsync(int sourceId);
    public Task<IEnumerable<IncomeMovement>> GetBySavingBagAsync(int savingBagId);
    public Task<IEnumerable<IncomeMovement>> GetBySavingBagAsync(SavingBagMovement savingBag);
    public Task<IEnumerable<IncomeMovement>> GetByExpenseAsync(ExpenseMovement expense);
    public Task<IEnumerable<IncomeMovement>> GetByExpenseAsync(int expenseId);
    public Task<IEnumerable<IncomeMovement>> GetByUserAsync(User user);
    public Task<IEnumerable<IncomeMovement>> GetByUserAsync(int userId);



}
