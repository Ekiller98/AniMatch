using MediatR;

namespace AniMatch.Application.Features.Anime.Queries.SearchAnime
{
    public record SearchAnimeQuery(string query) : IRequest<List<AnimeSearchResultDto>>
    {
    }
}
