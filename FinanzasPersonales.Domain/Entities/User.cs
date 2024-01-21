namespace FinanzasPersonales.Domain.Entities;

public class User : BaseDomainModel 
{
    public string NumeroIdentificacion { get; set; }
    public string Password { get; set; }
    public string Role { get; set; } = "Usuario";
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Gender { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Photo { get; set; }
    public string? State { get; set; }
    public virtual ICollection<ReviewRequest>? ReviewRequests { get; set; }
    public virtual ICollection<Reviewer>? Reviewers { get; set; }
    public virtual ICollection<FinancialMovement>? FinancialMovements { get; set; }

}
