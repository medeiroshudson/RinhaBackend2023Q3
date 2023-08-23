using RinhaBackend2023Q3.Domain.Entities.Common;

namespace RinhaBackend2023Q3.Domain.Interfaces.Services;

public interface IPersonService
{
    Person? Get(Guid id);
    ICollection<Person> GetAll();
    Person Add(Person person);
}
