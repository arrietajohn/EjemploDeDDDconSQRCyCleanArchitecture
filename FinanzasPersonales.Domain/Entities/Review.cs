namespace FinanzasPersonales.Domain.Entities;

public class Review : BaseDomainModel
{
    public int ReviewerId { get; set; }
    public DateTime Date { get; set; }
    public string Action { get; set; }
    public virtual Reviewer Reviewer { get; set; }
}

