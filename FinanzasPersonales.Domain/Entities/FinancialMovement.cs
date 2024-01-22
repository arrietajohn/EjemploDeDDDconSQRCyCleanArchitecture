namespace FinanzasPersonales.Domain.Entities;

public abstract class FinancialMovement : BaseDomainModel
{
    public decimal Value { get; set; }
    public DateTime Date { get; set; }
    public string? Name { get; set; }
    public int UserId { get; set; }
    public string? Description { get; set; }
    public virtual User User { get; set; }
}

