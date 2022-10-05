using PersonService.Application.Repositories.PersonRepository;
using PersonService.Domain.Entities;
using PersonService.Persistence.Contexts;

namespace PersonService.Persistence.Repositories.PersonRepository;

public class PersonReadRepository:ReadRepository<Person>,IPersonReadRepository
{
    public PersonReadRepository(TDPersonServiceContextDB context) : base(context)
    {
    }
}