using MediatR;
using PersonService.Application.Abstractions.Services;
using PersonService.Application.Utility.Results;
using PersonService.Domain.Entities;

namespace PersonService.Application.Features.Commands.DeletePerson;

public class DeletePersonCommandHandler:IRequestHandler<DeletePersonCommandRequest,IResult>
{
    private readonly IPersonService _personService;

    public DeletePersonCommandHandler(IPersonService personService)
    {
        _personService = personService;
    }

    public async Task<IResult> Handle(DeletePersonCommandRequest request, CancellationToken cancellationToken)
    {
        var result=await _personService.DeleteAsync(request.UUID);
        return result;
    }
}