using MediatR;
using PersonService.Application.Utility.Results;

namespace PersonService.Application.Features.Commands.DeletePerson;

public class DeletePersonCommandRequest:IRequest<IResult>
{
    public Guid UUID { get; set; }
}