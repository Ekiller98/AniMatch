using MediatR;
using AniMatch.Application.Common.Interfaces.Infrastructure;
using AniMatch.Application.Common.Models;
namespace AniMatch.Application.Features.Anime.Queries.ExternalSearchAnime
{
    public class ExternalSearchAnimeQueryHandler : IRequestHandler<ExternalSearchAnimeQuery, List<AniListAnimeDto>>
    {
        private readonly IAniListClient _aniListClient;

        public ExternalSearchAnimeQueryHandler(IAniListClient aniListClient)
        {
            _aniListClient = aniListClient;
        }

        public async Task<List<AniListAnimeDto>> Handle(ExternalSearchAnimeQuery request, CancellationToken cancellation)
        {
            var externalAnimeList = await _aniListClient.SearchAnimeAsync(request.query, cancellation);

            return externalAnimeList;
        }
    }
}
