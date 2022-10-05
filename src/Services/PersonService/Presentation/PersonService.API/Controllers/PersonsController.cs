using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonService.Application.DTOs.PersonDto;
using PersonService.Application.Features.Commands.CreatePerson;

namespace PersonService.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonsController : ControllerBase
{
  private readonly IMediator _mediator;
  private readonly IMapper _mapper;

  public PersonsController(IMediator mediator, IMapper mapper)
  {
    _mediator = mediator;
    _mapper = mapper;
  }

  [HttpPost("CreatePerson")]
  [ProducesResponseType(typeof(PersonDto),StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  public async Task<IActionResult> AddPerson([FromBody]CreatePersonCommandRequest commandRequest)
  {
    var result=await _mediator.Send(commandRequest);
    return result.Succes ? Ok(_mapper.Map<PersonDto>(result.Data)) : BadRequest(result.Message??String.Empty);
  }
}