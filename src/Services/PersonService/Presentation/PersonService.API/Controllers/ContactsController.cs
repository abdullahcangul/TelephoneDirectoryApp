using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonService.Application.DTOs.ContactDto;
using PersonService.Application.Features.Commands.ContactCommands.CreateContact;
using PersonService.Application.Features.Commands.ContactCommands.DeleteContact;
using PersonService.Domain.Entities;

namespace PersonService.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactsController:ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public ContactsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("CreateContact")]
    [ProducesResponseType(typeof(ContactDto),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateContact([FromBody]CreateContactCommandRequest commandRequest)
    {
        var result=await _mediator.Send(commandRequest);
        return result.Succes ? Ok(_mapper.Map<ContactDto>(result.Data)) : BadRequest(result.Message??String.Empty);
    }
  
    [HttpDelete("DeleteContact")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteContact([FromBody]DeleteContactCommandRequest commandRequest)
    {
        var result=await _mediator.Send(commandRequest);
        return result.Succes ? Ok() : BadRequest(result.Message??String.Empty);
    }
}