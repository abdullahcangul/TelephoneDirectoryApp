using AutoMapper;
using MediatR;
using PersonService.Application.Abstractions.Services;
using PersonService.Application.DTOs.PersonDto;
using PersonService.Application.Repositories.PersonRepository;
using PersonService.Application.Utility.Results;
using PersonService.Domain.Entities;

namespace PersonService.Application.Features.Commands.CreatePerson;

public class CreatePersonCommandHandler:IRequestHandler<CreatePersonCommandRequest,IDataResult<Person>>
{
    private readonly IPersonService _personService;
    private IMapper _mapper;

    public CreatePersonCommandHandler(IPersonService personService, IMapper mapper)
    {
        _personService = personService;
        _mapper = mapper;
    }

    public async Task<IDataResult<Person>> Handle(CreatePersonCommandRequest request, CancellationToken cancellationToken)
    {
        return await _personService.AddAsync(_mapper.Map<Person>(request));
    }
}