using AniMatch.Application.Common.Models.Anime;
using MediatR;

namespace AniMatch.Application.Features.Anime.Commands.ExternalAnimeImport
{
    public record ImportExternalAnimeCommand(int aniListId) : IRequest<AnimeDetailsDto?>
    {
    }
}
