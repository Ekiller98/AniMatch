using AniMatch.Application.Common.Interfaces.Auth;
using AniMatch.Application.Common.Models.Auth;
using MediatR;

namespace AniMatch.Application.Features.Auth.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResultDto?>
    {
        private readonly IAuthService _authService;
        public LoginCommandHandler(IAuthService authService) 
        {
            _authService = authService;
        }

        public async Task<AuthResultDto?> Handle(LoginCommand request, CancellationToken cancellation)
        {
            var authResult = await _authService.LoginAsync
                (
                    request.username,
                    request.password,
                    cancellation
                );

                return authResult;
        }
    }
}
