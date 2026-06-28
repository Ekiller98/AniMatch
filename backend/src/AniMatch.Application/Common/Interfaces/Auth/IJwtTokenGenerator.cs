namespace AniMatch.Application.Common.Interfaces.Auth
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(string userId, string username, string email, string displayName);
    }
}
