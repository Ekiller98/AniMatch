using AniMatch.Application.Common.Models;
using MediatR;

namespace AniMatch.Application.Features.Anime.Commands.ExternalAnimeImport
{
    public record ImportExternalAnimeCommand(int aniListId) : IRequest<AnimeDetailsDto?>
    {
    }
}
