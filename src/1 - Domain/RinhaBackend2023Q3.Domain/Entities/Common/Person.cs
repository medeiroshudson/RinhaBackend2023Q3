namespace RinhaBackend2023Q3.Domain.Entities.Common;

public class Person : AuditableEntity
{
    public required string Name { get; set; }
    public required string Nickname { get; set; }
    public DateTime BirthDate { get; set; }
    public ICollection<string>? Stack { get; set; }
}
