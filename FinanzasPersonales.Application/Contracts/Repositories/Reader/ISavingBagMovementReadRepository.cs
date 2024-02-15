using FinanzasPersonales.Domain.Entities;

namespace FinanzasPersonales.Application.Contracts.Repositories.Reader;

public interface ISavingBagMovementReadRepository<T> : IBaseDomainModelReadRepository<T> where T : SavingBagMovement
{
    public Task<IEnumerable<SavingBagMovement>> GetByProposedValueAsync(decimal value);
    public Task<IEnumerable<SavingBagMovement>> GetByProposedValueBetweenAsync(decimal value1, decimal value2);
    public Task<IEnumerable<SavingBagMovement>> GetMinProposedValueAsync();
    public Task<IEnumerable<SavingBagMovement>> GetMaxProposedValueAsync();
    public Task<IEnumerable<SavingBagMovement>> GetByPercentageAsync(decimal percentage);
    public Task<IEnumerable<SavingBagMovement>> GetByPercentageBetweenAsync(decimal percentage1, decimal percentage2);
    public Task<IEnumerable<SavingBagMovement>> GetMinPercentageAsync();
    public Task<IEnumerable<SavingBagMovement>> GetMaxPercentageAsync();
    public Task<IEnumerable<SavingBagMovement>> GetByBalanceValueAsync(decimal banaceValue);
    public Task<IEnumerable<SavingBagMovement>> GetByBalanceValueBetweenAsync(decimal banaceValue1, decimal banaceValue2);
    public Task<IEnumerable<SavingBagMovement>> GetMinBalanceValueAsync();
    public Task<IEnumerable<SavingBagMovement>> GetMaxBalanceValueAsync();
    public Task<IEnumerable<SavingBagMovement>> GetByStarDateAsync(DateTime startDate);
    public Task<IEnumerable<SavingBagMovement>> GetByStarDateBetweenAsync(DateTime startDate1, DateTime startDate2);
    public Task<IEnumerable<SavingBagMovement>> GetByPostponementDateAsync(DateTime postponementDate);
    public Task<IEnumerable<SavingBagMovement>> GetByPostponementDateBetweenAsync(DateTime date1, DateTime date2);
    public Task<IEnumerable<SavingBagMovement>> GetByStateAsync(string state);
    public Task<IEnumerable<SavingBagMovement>> GetByPurposeAsync(string purpose);
    public Task<SavingBagMovement> GetByIncomeAsync(int incomeId);
    public Task<SavingBagMovement> GetByIncomeAsync(IncomeMovement income);
    public Task<IEnumerable<SavingBagMovement>> GetByExpenseAsync(int expeneiId);
    public Task<IEnumerable<SavingBagMovement>> GetByExpenseAsync(ExpenseMovement expense);
    public Task<IEnumerable<SavingBagMovement>> GetByUserAsync(User user);
    public Task<IEnumerable<SavingBagMovement>> GetByUserAsync(int userId);
}
