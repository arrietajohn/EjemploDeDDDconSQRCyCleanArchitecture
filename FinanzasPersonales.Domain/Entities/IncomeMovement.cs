namespace FinanzasPersonales.Domain.Entities;

public class IncomeMovement : FinancialMovement
{
    public decimal ValueSaved { get; set; }
    public decimal BalanceValue { get; set; }
    public int SourceId { get; set; }
    public virtual Source Source { get; set; }

    public int? SavingBagMovementId { get; set; }
    public virtual SavingBagMovement? SavingBagMovement { get; set; }
    public virtual ICollection<ExpenseAndIncome>? ExpenseAndIncomes { get; set; } = new List<ExpenseAndIncome>();

}
