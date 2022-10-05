using FluentValidation;
using PersonService.Application.Features.Commands.DeletePerson;

namespace PersonService.Application.Features.Commands.CreatePerson;

public class DeletePersonValidators: AbstractValidator<DeletePersonCommandRequest>
{
    public DeletePersonValidators()
    {
        RuleFor(cp => cp.UUID)
            .NotNull()
            .NotEmpty();
    }
}