using DfdsLunchBuddy.Application.Authentication.Commands.Register;
using DfdsLunchBuddy.Application.Authentication.Common;
using DfdsLunchBuddy.Application.Authentication.Queries.Login;
using DfdsLunchBuddy.Application.Buddy.Commands;
using DfdsLunchBuddy.Contracts.Authentication;
using DfdsLunchBuddy.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DfdsLunchBuddy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserDetailsController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public UserDetailsController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("update-details")]
        public async Task<IActionResult> UpdateUserDetails(UpdateBuddyDetailsRequest request)
        {
            var command = _mapper.Map<UpdateUserWorkPlaceCommand>(request);
            ErrorOr<UpdatedUserResult> authResult = await _mediator.Send(command);

            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors));
        }
    }
}