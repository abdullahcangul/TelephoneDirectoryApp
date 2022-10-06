using MediatR;
using PersonService.Application.Utility.Results;
using PersonService.Domain.Entities;

namespace PersonService.Application.Features.Commands.ContactCommands.CreateContact;

public class CreateContactCommandRequest:IRequest<IDataResult<Contact>>
{
    public string? TelNo { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }

    public Guid PersonUUID { get; set; }
}