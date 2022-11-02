using DfdsLunchBuddy.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace DfdsLunchBuddy.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;