using AniMatch.Application.Common.Models.Auth;
using MediatR;
namespace AniMatch.Application.Features.Auth.Commands.Login
{
    public record LoginCommand(string username, string password) : IRequest<AuthResultDto?>
    {
    }
}
