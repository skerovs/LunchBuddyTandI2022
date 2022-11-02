using DfdsLunchBuddy.Application.Authentication.Commands.Register;
using FluentValidation;

namespace DfdsLunchBuddy.Application.Buddy.Commands;

public class UpdateUserWorkPlaceCommandValidator : AbstractValidator<UpdateUserWorkPlaceCommand>
{
    public UpdateUserWorkPlaceCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty();
    }
}