namespace FinanzasPersonales.Domain.Entities;

public class SavingBagMovement : FinancialMovement
{
    public decimal ProposedValue { get; set; }
    public decimal Percentage { get; set; }
    public decimal BalanceValue { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndingDate { get; set; }
    public DateTime? PostponementDate { get; set; }
    public string? State { get; set; }
    public string? Purpose { get; set; }

    public virtual ICollection<IncomeMovement>? IncomeMovements { get; set; } = new List<IncomeMovement>();
    public virtual ICollection<ExpenseAndSavingBag>? ExpenseAndSavingBags { get; set; } = new List<ExpenseAndSavingBag>();
}

