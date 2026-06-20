using AniMatch.Application.Common.Models.Auth;
using MediatR;
namespace AniMatch.Application.Features.Auth.Commands.Register
{
    public record RegisterCommand(string email, string username, string displayName, string password) : IRequest<AuthResultDto>
    {
    }
}
