using Microsoft.EntityFrameworkCore;
using PersonService.Application.Abstractions.Services;
using PersonService.Application.DTOs.ReportDto;
using PersonService.Application.Repositories;
using PersonService.Application.Repositories.PersonRepository;
using PersonService.Application.Utility.Results;
using PersonService.Domain.Entities;

namespace PersonService.Persistence.Services;

public class PersonManager:BaseManager<Person>,IPersonService
{
    private readonly IPersonReadRepository _personReadRepository;
    public PersonManager(IReadRepository<Person> readRepository, IWriteRepository<Person> writeRepository, IPersonReadRepository personReadRepository) : base(readRepository, writeRepository)
    {
        _personReadRepository = personReadRepository;
    }

    public async Task<IDataResult<List<Person>>> GetPersonWitContacts()
    {
      return new SuccessDataResult<List<Person>>(
              await _personReadRepository
                  .GetAll()
                  .Include(p => p.Contacts)
                  .ToListAsync()
          );
    }

    
}