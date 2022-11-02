using DfdsLunchBuddy.Application.Authentication.Common;
using DfdsLunchBuddy.Application.Common.Interfaces.Authentication;
using DfdsLunchBuddy.Application.Common.Interfaces.Persistence;
using DfdsLunchBuddy.Domain.Common.Errors;
using DfdsLunchBuddy.Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace DfdsLunchBuddy.Application.Buddy.Commands;

public record UpdateUserWorkPlaceCommand(
    string Email,
    string TeamName,
    int DepartmentId) : IRequest<ErrorOr<UpdatedUserResult>>;


public class UpdateUserWorkPlaceCommnadHandler :
    IRequestHandler<UpdateUserWorkPlaceCommand, ErrorOr<UpdatedUserResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IDepartmentRepository _departmentRepository;

    public UpdateUserWorkPlaceCommnadHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository,
        IDepartmentRepository departmentRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _departmentRepository = departmentRepository;
    }

    public async Task<ErrorOr<UpdatedUserResult>> Handle(UpdateUserWorkPlaceCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var user = _userRepository.GetUserByEmail(command.Email);

        if (user is null)
        {
            return Errors.User.NotFound;
        }

        var department = _departmentRepository.GetDepartmentById(command.DepartmentId);
        user.UpdateUserWorkPlace(department, new DepartmentTeam(command.TeamName));

        _userRepository.UpdateUser(user);

        return new UpdatedUserResult(user);
    }
}