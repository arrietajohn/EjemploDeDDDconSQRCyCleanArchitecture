﻿using FinanzasPersonales.Domain.Entities;

namespace FinanzasPersonales.Application.Contracts.Repositories.Reader;

public interface IExpenseAndSavingBagReadRepository<T> : IBaseDomainModelReadRepository<T> where T : ExpenseAndSavingBag
{

    public Task<IEnumerable<ExpenseAndSavingBag>> GetByValueAsync(decimal value);
    public Task<IEnumerable<ExpenseAndSavingBag>> GetByValueBetweenAsync(decimal value1, decimal value2);
    public Task<IEnumerable<ExpenseAndSavingBag>> GetMinValueAsync();
    public Task<IEnumerable<ExpenseAndSavingBag>> GetMaxValueAsync();
    public Task<IEnumerable<ExpenseAndSavingBag>> GetByPercentageAsync(decimal percentege);
    public Task<IEnumerable<ExpenseAndSavingBag>> GetByPercentageBetweenAsync(decimal percentage1, decimal percentage2);
    public Task<IEnumerable<ExpenseAndSavingBag>> GetMixPercentageAsync();
    public Task<IEnumerable<ExpenseAndSavingBag>> GetMaxPercentageAsync();
    public Task<IEnumerable<ExpenseAndSavingBag>> GetByExpenseAsync(int expense);
    public Task<IEnumerable<ExpenseAndSavingBag>> GetByExpenseAsync(ExpenseMovement expense);
    public Task<IEnumerable<ExpenseAndSavingBag>> GetByIncomeAsync(int savingBag);
    public Task<IEnumerable<ExpenseAndSavingBag>> GetByIncomeAsync(SavingBagMovement savingBag);
}
