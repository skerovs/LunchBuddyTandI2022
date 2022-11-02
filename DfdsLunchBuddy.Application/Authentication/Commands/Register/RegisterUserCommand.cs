using DfdsLunchBuddy.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace DfdsLunchBuddy.Application.Authentication.Commands.Register;

public record RegisterUserCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    int departmentId,
    string teamName) : IRequest<ErrorOr<AuthenticationResult>>;