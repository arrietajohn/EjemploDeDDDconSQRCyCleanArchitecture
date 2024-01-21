namespace FinanzasPersonales.Domain.Entities;

public abstract class BaseDomainModel
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime FechaModificacion { get; set; }

}

