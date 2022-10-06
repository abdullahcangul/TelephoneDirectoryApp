using FluentValidation;
using PersonService.Application.Features.Commands.ContactCommands.CreateContact;

namespace PersonService.Application.Features.Commands.CreatePerson;

public class CreateContactValidators: AbstractValidator<CreateContactCommandRequest>
{
    public CreateContactValidators()
    {
        RuleFor(cc => cc.PersonUUID)
            .NotNull()
            .NotEmpty();

        RuleFor(cp => cp.TelNo)
            .MaximumLength(10);
            
        
        RuleFor(cp => cp.Email)
            .MaximumLength(50)
            .EmailAddress();

        RuleFor(cp => cp.Address)
            .MaximumLength(250);

    }
}