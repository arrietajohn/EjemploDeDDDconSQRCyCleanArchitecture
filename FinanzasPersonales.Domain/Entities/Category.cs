namespace FinanzasPersonales.Domain.Entities;

public class Category : BaseDomainModel
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public virtual ICollection<ExpenseMovement>? ExpenseMovements { get; set; } = new List<ExpenseMovement>();
}


