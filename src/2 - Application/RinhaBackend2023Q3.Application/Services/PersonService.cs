using RinhaBackend2023Q3.Domain.Entities.Common;
using RinhaBackend2023Q3.Domain.Interfaces.Infra.Context;
using RinhaBackend2023Q3.Domain.Interfaces.Services;
using RinhaBackend2023Q3.Infra.Data.Context;
using RinhaBackend2023Q3.Infra.Data.Extensions;

namespace RinhaBackend2023Q3.Application.Services;

public sealed class PersonService : IPersonService
{
    private readonly ApplicationDbContext _context;
    private readonly IUnitOfWork _unitOfWork;

    public PersonService(ApplicationDbContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    public Person? Get(Guid id) => _context.GetById<Person>(id);

    public ICollection<Person> GetAll() => _context.GetAll<Person>();

    public Person Add(Person person)
    {
        _context.Add(person);
        _unitOfWork.Commit();

        return person;
    }
}
