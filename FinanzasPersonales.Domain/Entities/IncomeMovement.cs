namespace FinanzasPersonales.Domain.Entities;

public class IncomeMovement : FinancialMovement
{
    public int SourceId { get; set; }
    public virtual Source Source { get; set; }
    public int? SavingBagMovementId { get; set; }
    public virtual SavingBagMovement? SavingBagMovement { get; set; }
    public decimal ValueSaved { get; set; }
    public virtual ICollection<ExpenseAndIncome>? ExpenseAndIncomes { get; set; }

}
