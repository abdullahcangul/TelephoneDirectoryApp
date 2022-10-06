using FluentValidation;
using PersonService.Application.Features.Commands.DeletePerson;

namespace PersonService.Application.Features.Commands.CreatePerson;

public class DeleteContactValidators: AbstractValidator<DeletePersonCommandRequest>
{
    public DeleteContactValidators()
    {
        RuleFor(cp => cp.UUID)
            .NotNull()
            .NotEmpty();
    }
}