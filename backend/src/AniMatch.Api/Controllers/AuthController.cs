using MediatR;
using Microsoft.AspNetCore.Mvc;
using AniMatch.Application.Features.Auth.Commands.Login;
using AniMatch.Application.Common.Models.Auth;
using AniMatch.Application.Features.Auth.Commands.Register;


namespace AniMatch.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResultDto>> Register([FromBody] RegisterCommand command, CancellationToken cancellation)
        {
            var authResult = await _mediator.Send(command, cancellation);

             return Ok(authResult);
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResultDto?>> Login([FromBody] LoginCommand command, CancellationToken cancellation)
        {
            var authResult = await _mediator.Send(command, cancellation);

            if (authResult == null)
            {
                return Unauthorized("Invalid username or password");
            }
            return Ok(authResult);
        }

    }
}
