using DfdsLunchBuddy.Application.Authentication.Commands.Register;
using FluentValidation;

namespace DfdsLunchBuddy.Application.Buddy.Commands;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
        RuleFor(x => x.Password.Length).GreaterThan(6);
    }
}