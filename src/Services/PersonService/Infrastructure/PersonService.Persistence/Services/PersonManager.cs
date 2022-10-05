using PersonService.Application.Abstractions.Services;
using PersonService.Application.Repositories;
using PersonService.Domain.Entities;

namespace PersonService.Persistence.Services;

public class PersonManager:BaseManager<Person>,IPersonService
{
    public PersonManager(IReadRepository<Person> readRepository, IWriteRepository<Person> writeRepository) : base(readRepository, writeRepository)
    {
    }
}