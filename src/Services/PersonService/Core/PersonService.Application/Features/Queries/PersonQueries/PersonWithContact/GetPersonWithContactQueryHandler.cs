using MediatR;
using PersonService.Application.Abstractions.Services;
using PersonService.Application.Utility.Results;
using PersonService.Domain.Entities;

namespace PersonService.Application.Features.Queries.PersonQueries.PersonWithContact;

public class GetPersonWithContactQueryHandler:IRequestHandler<GetPersonWithContactQueryRequest,IDataResult<List<Person>>>
{
    private readonly IPersonService _personService;

    public GetPersonWithContactQueryHandler(IPersonService personService)
    {
        _personService = personService;
    }

    public async Task<IDataResult<List<Person>>> Handle(GetPersonWithContactQueryRequest request, CancellationToken cancellationToken)
    {
        return await _personService.GetPersonWitContacts();
    }
}