using MediatR;
using PersonService.Application.Utility.Results;
using PersonService.Domain.Entities;

namespace PersonService.Application.Features.Queries.PersonQueries.PersonWithContact;

public class GetPersonWithContactQueryRequest:IRequest<IDataResult<List<Person>>>
{
    
}