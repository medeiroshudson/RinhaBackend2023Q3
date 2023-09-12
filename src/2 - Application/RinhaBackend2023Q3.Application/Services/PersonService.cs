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

    public async Task<Person?> Get(Guid id) => await _context.GetByIdAsync<Person>(id);

    public async Task<ICollection<Person>> GetAll() => await _context.GetAllAsync<Person>();

    public async Task Add(Person person)
    {
        await _context.AddAsync(person);
        await _unitOfWork.CommitAsync();
    }

    public async Task Update(Person person)
    {
        await _context.UpdateAsync(person);
        await _unitOfWork.CommitAsync();
    }

    public async Task Delete(Guid id)
    {
        await _context.RemoveAsync<Person>(id);
        await _unitOfWork.CommitAsync();
    }
}
