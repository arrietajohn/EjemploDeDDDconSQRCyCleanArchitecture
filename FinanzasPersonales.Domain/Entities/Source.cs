namespace FinanzasPersonales.Domain.Entities;

public class Source : BaseDomainModel 
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public virtual ICollection<IncomeMovement>? IncomeMovements { get; set; }
}