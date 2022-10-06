using FluentValidation;

namespace PersonService.Application.Features.Commands.CreatePerson;

public class CreatePersonValidators: AbstractValidator<CreatePersonCommandRequest>
{
    public CreatePersonValidators()
    {
        RuleFor(cp => cp.Name)
            .MaximumLength(50)
            .NotNull()
            .NotEmpty();
        
        RuleFor(cp => cp.Surname)
            .MaximumLength(50)
            .NotNull()
            .NotEmpty();
    }
}