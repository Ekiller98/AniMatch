using AniMatch.Application.Common.Interfaces.Auth;
using AniMatch.Application.Common.Models.Auth;
using AniMatch.Persistence.Identity;
using Microsoft.AspNetCore.Identity;

namespace AniMatch.Persistence.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService (UserManager<ApplicationUser> userManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userManager = userManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<AuthResultDto> RegisterAsync(string email, string username, string displayName, string password, CancellationToken cancellation)
        {
            var newUser = new ApplicationUser
            {
                Email = email,
                UserName = username,
                DisplayName = displayName,
            };

            var result = await _userManager.CreateAsync(newUser, password);

            if (!result.Succeeded)
            {
                throw new InvalidOperationException(
                    string.Join(", ", result.Errors.Select(error => error.Description)));
            }

            var token = _jwtTokenGenerator.GenerateToken
                (
                    newUser.Id,
                    newUser.UserName ?? string.Empty,
                    newUser.Email ?? string.Empty,
                    newUser.DisplayName
                );

            return new AuthResultDto
            {
                UserId = newUser.Id,
                Email = newUser.Email ?? string.Empty,
                UserName = newUser.UserName ?? string.Empty,
                DisplayName = newUser.DisplayName,
                Token = token
            };
        }

        public async Task<AuthResultDto?> LoginAsync(string username, string password, CancellationToken cancellation)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return null;  
            }

            var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, password);

            if (!isPasswordCorrect)
            {
                return null;
            }

            var token = _jwtTokenGenerator.GenerateToken
                (
                    user.Id,
                    user.UserName ?? string.Empty,
                    user.Email ?? string.Empty,
                    user.DisplayName
                );

            return new AuthResultDto
            {
                UserId = user.Id,
                Email = user.Email ?? string.Empty,
                UserName = user.UserName ?? string.Empty,
                DisplayName = user.DisplayName,
                Token = token
            };
        }
    }
}
