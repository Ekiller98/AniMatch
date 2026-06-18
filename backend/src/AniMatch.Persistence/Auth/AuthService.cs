

using AniMatch.Application.Common.Interfaces.Auth;
using AniMatch.Application.Common.Models.Auth;
using AniMatch.Persistence.Identity;
using Microsoft.AspNetCore.Identity;

namespace AniMatch.Persistence.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthService (UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
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

            return new AuthResultDto
            {
                UserId = newUser.Id,
                Email = newUser.Email ?? string.Empty,
                UserName = newUser.UserName ?? string.Empty,
                DisplayName = newUser.DisplayName,
                Token = string.Empty
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

            return new AuthResultDto
            {
                UserId = user.Id,
                Email = user.Email ?? string.Empty,
                UserName = user.UserName ?? string.Empty,
                DisplayName = user.DisplayName,
                Token = string.Empty
            };
        }
    }
}
