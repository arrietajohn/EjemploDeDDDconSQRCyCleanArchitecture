namespace FinanzasPersonales.Domain.Entities;

public class ExpenseAndSavingBag : BaseDomainModel
{
    public int ExpenseMovementId { get; set; }
    public virtual ExpenseMovement ExpenseMovement { get; set; }
    public int SavingBagMovementiD { get; set; }
    public virtual SavingBagMovement SavingBagMovement { get; set; }
    public decimal Value { get; set; }
    public decimal Percentage { get; set; }
}