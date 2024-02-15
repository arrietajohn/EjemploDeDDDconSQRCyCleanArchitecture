using FinanzasPersonales.Domain.Entities;

namespace FinanzasPersonales.Application.Contracts.Repositories.Reader;

public interface IExpenseAndIcomeReadRepository<T> : IBaseDomainModelReadRepository<T> where T : ExpenseAndIncome
{

    public Task<IEnumerable<ExpenseAndIncome>> GetByValueAsync(decimal value);
    public Task<IEnumerable<ExpenseAndIncome>> GetByValueBetweenAsync(decimal value1, decimal value2);
    public Task<IEnumerable<ExpenseAndIncome>> GetByMinValueAsync();
    public Task<IEnumerable<ExpenseAndIncome>> GetMaxValueAsync();
    public Task<IEnumerable<ExpenseAndIncome>> GetByPercentageAsync(decimal percentege);
    public Task<IEnumerable<ExpenseAndIncome>> GetByPercentageBetweenAsync(decimal porcentege1, decimal porcentege2);
    public Task<IEnumerable<ExpenseAndIncome>> GetByExpenseAsync(int expense);
    public Task<IEnumerable<ExpenseAndIncome>> GetByExpenseAsync(ExpenseMovement expense);
    public Task<IEnumerable<ExpenseAndIncome>> GetByIncomeAsync(int incomeId);
    public Task<IEnumerable<ExpenseAndIncome>> GetByIncomeAsync(IncomeMovement income);

}
