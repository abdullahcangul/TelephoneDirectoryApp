using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonService.Application.DTOs.ReportDtos;
using PersonService.Application.Features.Commands.ReportCommand.CreateReport;
using PersonService.Application.Features.Queries.ReportQueries.GetReports;
using PersonService.Application.Features.Queries.ReportQueries.GetReportsWithDetails;

namespace ReportService.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportsController:ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public ReportsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("GetReports")]
    [ProducesResponseType(typeof(List<ReportDto>),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetReports()
    {
        var result=await _mediator.Send(new GetReportQueryRequest());
        return result.Succes ? Ok(_mapper.Map<List<ReportDto>>(result.Data)) : BadRequest(result.Message??String.Empty);
    }
    
    [HttpGet("GetReportsWithReportDetail")]
    [ProducesResponseType(typeof(List<ReportsWithDetailsDto>),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetReportsWithDetails()
    {
        var result=await _mediator.Send(new GetReportsWithDetailQueryRequest());
        return result.Succes ? Ok(_mapper.Map<List<ReportsWithDetailsDto>>(result.Data)) : BadRequest(result.Message??String.Empty);
    }
    
    [HttpPost("CreateReport")]
    [ProducesResponseType(typeof(string),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateReport([FromBody]CreateReportCommandRequest commandRequest)
    {
        var result=await _mediator.Send(commandRequest);
        return result.Succes ? Ok(result.Message) : BadRequest(result.Message??String.Empty);
    }
}