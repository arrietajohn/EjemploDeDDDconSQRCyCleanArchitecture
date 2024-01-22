namespace FinanzasPersonales.Domain.Entities;

public class ExpenseMovement : FinancialMovement
{
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public int Priority { get; set; }
    public virtual ICollection<ExpenseAndSavingBag>? ExpenseAndSavingBags { get; set; } = new List<ExpenseAndSavingBag>();
    public virtual ICollection<ExpenseAndIncome>? ExpenseAndIncomes { get; set; } = new List<ExpenseAndIncome>();
}

