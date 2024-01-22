namespace FinanzasPersonales.Domain.Entities;

public class ReviewRequest : BaseDomainModel
{
    public string? Subjet { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndingDate { get; set; }
    public string? State { get; set; }
    public string? Reason { get; set; }
    public int RequestingUserId { get; set; }
    public virtual User RequestingUser { get; set; }
    public int RequestedUserId { get; set; }
    public virtual User RequestedUser { get; set; }
    public int? ReviewerId { get; set; }
    public virtual Reviewer? Reviewer { get; set; }
}

