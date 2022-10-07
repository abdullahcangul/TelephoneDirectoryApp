using MediatR;
using ReportService.Application.Utility.Results;
using ReportService.Domain;

namespace PersonService.Application.Features.Commands.ReportCommand.CreateReport;

public class CreateReportCommandRequest:IRequest<IResult>
{
    public string Name { get; set; }
}