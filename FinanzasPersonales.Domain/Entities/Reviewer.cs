namespace FinanzasPersonales.Domain.Entities;

public class Reviewer : BaseDomainModel
{

    public DateTime StartDate { get; set; }
    public DateTime EndingDate { get; set; }
    public string? State { get; set; }
    public bool ViewEmail { get; set; }
    public bool ViewPhoneNumber { get; set; }
    public bool ViewAddress { get; set; }
    public bool ViewPhoto { get; set; }
    public int ReviewRequestId { get; set; }
    public int ReviewedUserId { get; set; }
    public virtual User ReviewedUser { get; set; }
    public int ReviewerUserId { get; set; }
    public virtual User ReviewerUser { get; set; }
    public virtual ReviewRequest ReviewRequest { get; set; }
    public virtual ICollection<Review>? Reviews { get; set; } = new List<Review>();
}
