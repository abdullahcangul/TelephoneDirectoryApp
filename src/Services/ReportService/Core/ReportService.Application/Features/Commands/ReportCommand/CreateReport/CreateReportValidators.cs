using FluentValidation;
using PersonService.Application.Features.Commands.ReportCommand.CreateReport;

namespace PersonService.Application.Features.Commands.CreatePerson;

public class CreateReportValidators: AbstractValidator<CreateReportCommandRequest>
{
    public CreateReportValidators()
    {
        RuleFor(cp => cp.Name)
            .MaximumLength(100)
            .NotNull()
            .NotEmpty();
    }
}