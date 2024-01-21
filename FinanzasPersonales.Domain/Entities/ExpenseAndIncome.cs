namespace FinanzasPersonales.Domain.Entities;

public class ExpenseAndIncome : BaseDomainModel
{
    public int ExpenseMovementId { get; set; }
    public virtual ExpenseMovement ExpenseMovement { get; set; }
    public int IncomeMovementId { get; set; }
    public virtual IncomeMovement IncomeMovement { get; set; }
    public decimal Value { get; set; }
    public decimal Percentage { get; set; }
}