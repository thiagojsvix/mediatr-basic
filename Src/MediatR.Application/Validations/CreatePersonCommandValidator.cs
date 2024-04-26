using FluentValidation;

using MediatR.Application.Commands;

namespace MediatR.Application.Validations;

public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
{
    public CreatePersonCommandValidator()
    {
        RuleFor(c => c.FirstName)
            .NotEmpty()
            .WithMessage("Please ensure you have entered the FirstName")
            .Length(4, 100)
            .WithMessage("The FirstName must have between 4 and 150 characters");

        RuleFor(c => c.LastName)
           .NotEmpty()
           .WithMessage("Please ensure you have entered the LastName")
           .Length(4, 100)
           .WithMessage("The LastName must have between 4 and 150 characters");

        RuleFor(c => c.Gender)
            .NotEmpty()
            .MinimumLength(4)
            .WithMessage("The gender must be a valid information");

        RuleFor(c => c.Email)
           .NotEmpty()
           .EmailAddress();

        RuleFor(x => x.IsActive)
            .NotNull();
    }
}
