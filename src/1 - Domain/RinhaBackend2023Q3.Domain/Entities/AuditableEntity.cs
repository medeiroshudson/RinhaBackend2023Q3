using RinhaBackend2023Q3.Domain.Interfaces;

namespace RinhaBackend2023Q3.Domain.Entities;

public abstract class AuditableEntity : IAuditableEntity
{
    public Guid Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Guid? UpdatedBy { get; set; }
}
