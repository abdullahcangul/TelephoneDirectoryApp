using PersonService.Domain.Entities;

namespace PersonService.Application.Repositories.PersonRepository;

public interface IPersonWriteRepository:IWriteRepository<Person>
{
    
}