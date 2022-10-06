using AutoMapper;
using MediatR;
using PersonService.Application.Abstractions.Services;
using PersonService.Application.Utility.Results;
using PersonService.Domain.Entities;

namespace PersonService.Application.Features.Commands.ContactCommands.CreateContact;

public class CreateContactCommandHandler:IRequestHandler<CreateContactCommandRequest,IDataResult<Contact>>
{
    private readonly IContactService _contactService;
    private readonly IMapper _mapper;

    public CreateContactCommandHandler(IContactService contactService, IMapper mapper)
    {
        _contactService = contactService;
        _mapper = mapper;
    }

    public async Task<IDataResult<Contact>> Handle(CreateContactCommandRequest request, CancellationToken cancellationToken)
    {
       return await _contactService.AddAsync(_mapper.Map<Contact>(request));
    }
}