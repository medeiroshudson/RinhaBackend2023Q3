using RinhaBackend2023Q3.Domain.Interfaces;

namespace RinhaBackend2023Q3.Domain.Entities;

public abstract class Entity : IEntity
{
    public Guid Id { get; set; }
}
