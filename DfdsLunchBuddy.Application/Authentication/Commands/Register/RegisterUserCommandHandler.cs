using DfdsLunchBuddy.Application.Authentication.Common;
using DfdsLunchBuddy.Application.Common.Interfaces.Authentication;
using DfdsLunchBuddy.Application.Common.Interfaces.Persistence;
using DfdsLunchBuddy.Domain;
using DfdsLunchBuddy.Domain.Common.Errors;
using DfdsLunchBuddy.Domain.DomainObjects;
using DfdsLunchBuddy.Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace DfdsLunchBuddy.Application.Authentication.Commands.Register;

public class RegisterUserCommandHandler :
    IRequestHandler<RegisterUserCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IDepartmentRepository _departmentRepository;

    public RegisterUserCommandHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository,
        IDepartmentRepository departmentRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _departmentRepository = departmentRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // 1. Validate the user doesn't exist
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        // 2. Create user (generate unique ID) & Persist to DB
        var password = new Password(command.Password);
        var user = User.CreateNewUser(command.FirstName, command.LastName, command.Email, password);
        var userTeam = new DepartmentTeam(command.teamName);
        var userDepartment = _departmentRepository.GetDepartmentById(command.departmentId);
        user.UpdateUserWorkPlace(userDepartment, userTeam);
        _userRepository.Add(user);

        // 3. Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}