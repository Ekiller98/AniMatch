using MediatR;
using AniMatch.Application.Common.Models.Anime;


namespace AniMatch.Application.Features.Anime.Queries.ExternalSearchAnime
{
    public record ExternalSearchAnimeQuery(string query) : IRequest<List<AniListAnimeDto>>
    {
    }
}
