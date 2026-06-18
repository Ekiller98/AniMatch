
using AniMatch.Application.Common.Models.Auth;

namespace AniMatch.Application.Common.Interfaces.Auth
{
    public interface IAuthService
    {
        Task<AuthResultDto> RegisterAsync(string email, string username, string displayName, string password, CancellationToken cancellation);

        Task<AuthResultDto?> LoginAsync(string username,string password, CancellationToken cancellation);

    }
}
