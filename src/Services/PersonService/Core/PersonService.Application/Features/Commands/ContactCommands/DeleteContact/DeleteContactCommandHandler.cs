using MediatR;
using PersonService.Application.Abstractions.Services;
using PersonService.Application.Utility.Results;

namespace PersonService.Application.Features.Commands.ContactCommands.DeleteContact;

public class DeleteContactCommandHandler:IRequestHandler<DeleteContactCommandRequest,IResult>
{
    private readonly IContactService _contactService;

    public DeleteContactCommandHandler(IContactService contactService)
    {
        _contactService = contactService;
    }

    public async Task<IResult> Handle(DeleteContactCommandRequest request, CancellationToken cancellationToken)
    {
        var result=await _contactService.DeleteAsync(request.UUID);
        return result;
    }
}