using MediatR;
using PersonService.Application.DTOs.PersonDto;
using PersonService.Application.Utility.Results;
using PersonService.Domain.Entities;

namespace PersonService.Application.Features.Commands.CreatePerson;

public class CreatePersonCommandRequest:IRequest<IDataResult<Person>>
{
    public string Name { get; set; }
    public string Surname { get; set; }
}