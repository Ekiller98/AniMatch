

using AniMatch.Application.Common.Interfaces.Auth;
using AniMatch.Application.Common.Models.Auth;
using MediatR;

namespace AniMatch.Application.Features.Auth.Commands.Register
{
    public class LoginCommandHandler : IRequestHandler<RegisterCommand, AuthResultDto>
    {
        private readonly IAuthService _authService;
        public LoginCommandHandler(IAuthService authService) 
        {
            _authService = authService;
        }

        public async Task<AuthResultDto> Handle(RegisterCommand request, CancellationToken cancellation)
        {
            var authResult = await _authService.RegisterAsync
                (
                    request.email,
                    request.username,
                    request.displayName,
                    request.password,
                    cancellation
                );

                return authResult;
        }
    }
}
