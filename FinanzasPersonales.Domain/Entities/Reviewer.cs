namespace FinanzasPersonales.Domain.Entities;

public class Reviewer : BaseDomainModel
{
    public int UserId { get; set; }
    public int ReviewerUserId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndingDate { get; set; }
    public string? State { get; set; }
    public bool ViewEmail { get; set; }
    public bool ViewPhoneNumber { get; set; }
    public bool ViewAddress { get; set; }
    public bool ViewPhoto { get; set; }
    public int? ReviewRequestId { get; set; }
    public virtual User User { get; set; }
    public virtual User ReviewerUser { get; set; }
    public virtual ICollection<Review>? Reviews { get; set; }
}
