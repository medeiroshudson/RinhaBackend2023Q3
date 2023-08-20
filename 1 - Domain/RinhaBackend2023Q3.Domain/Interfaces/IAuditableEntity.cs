namespace RinhaBackend2023Q3.Domain;

public interface IAuditableEntity : IEntity
{
    public DateTime? CreatedAt { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Guid? UpdatedBy { get; set; }
}
