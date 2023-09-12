using RinhaBackend2023Q3.Domain.Entities.Common;

namespace RinhaBackend2023Q3.Domain.Interfaces.Services;

public interface IPersonService
{
    Task<Person?> Get(Guid id);
    Task<ICollection<Person>> GetAll();
    Task Add(Person person);
    Task Update(Person person);
    Task Delete(Guid id);
}
