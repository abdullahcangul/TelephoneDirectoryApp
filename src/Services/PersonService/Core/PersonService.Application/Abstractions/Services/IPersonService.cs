using PersonService.Application.DTOs.ReportDto;
using PersonService.Application.Utility.Results;
using PersonService.Domain.Entities;

namespace PersonService.Application.Abstractions.Services;

public interface IPersonService:IBaseService<Person>
{
    public Task<IDataResult<List<Person>>> GetPersonWitContacts();
    
}