namespace FinanzasPersonales.Domain.Entities;

public class User : BaseDomainModel 
{
    public string? NumeroIdentificacion { get; set; }
    public string Password { get; set; } = new Guid().ToString();
    public string Role { get; set; } = "Usuario";
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Gender { get; set; } = "Masculino";
    public DateTime? BirthDate { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Photo { get; set; }
    public string? State { get; set; }
    public virtual ICollection<ReviewRequest>? SentReviewRequests { get; set; } = new List<ReviewRequest>();
    public virtual ICollection<ReviewRequest>? ReceivedReviewRequests { get; set; } = new List<ReviewRequest>();
    public virtual ICollection<Reviewer>? ReviewerUsers { get; set; } = new List<Reviewer>();  
    public virtual ICollection<Reviewer>? ReviewedUsers { get; set; } = new List<Reviewer>();
    public virtual ICollection<FinancialMovement>? FinancialMovements { get; set; } = new List<FinancialMovement>();

}
