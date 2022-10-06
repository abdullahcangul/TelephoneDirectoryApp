using MediatR;
using PersonService.Application.Utility.Results;

namespace PersonService.Application.Features.Commands.ContactCommands.DeleteContact;

public class DeleteContactCommandRequest:IRequest<IResult>
{
    public Guid UUID { get; set; }
}