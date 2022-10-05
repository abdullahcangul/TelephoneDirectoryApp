using PersonService.Application.Repositories;
using PersonService.Application.Repositories.PersonRepository;
using PersonService.Domain.Entities;
using PersonService.Persistence.Contexts;

namespace PersonService.Persistence.Repositories.PersonRepository;

public class PersonWriteRepository:WriteRepository<Person>,IPersonWriteRepository
{
    public PersonWriteRepository(TDPersonServiceContextDB context) : base(context)
    {
    }
}