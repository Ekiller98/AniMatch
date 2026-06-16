using MediatR;
using AniMatch.Application.Common.Interfaces.Persistence;
using AniMatch.Application.Common.Interfaces.Infrastructure;
using AniMatch.Application.Common.Models.Anime;

namespace AniMatch.Application.Features.Anime.Queries.SearchAnime
{
    public class SearchAnimeQueryHandler : IRequestHandler<SearchAnimeQuery, List<AnimeSearchResultDto>>
    {
        private readonly IAnimeRepository _animeRepository;
        private readonly IAniListClient _aniListClient;

        public SearchAnimeQueryHandler(IAnimeRepository animeRepository, IAniListClient aniListClient) 
        {
            _animeRepository = animeRepository;
            _aniListClient = aniListClient;
        }

        public async Task<List<AnimeSearchResultDto>> Handle(SearchAnimeQuery request, CancellationToken cancellation)
        {
            var localAnimeList = await _animeRepository.SearchAsync(request.query, cancellation);

            var localResults = localAnimeList.Select(localAnime => new AnimeSearchResultDto
             {
                 Id = localAnime.Id,
                 AniListId = localAnime.AniListId,
                 Title = localAnime.TitleEnglish ?? localAnime.TitleRomaji,
                 CoverImageUrl = localAnime.CoverImageUrl,
                 Format = localAnime.Format,
                 Status = localAnime.Status,
                 Episodes = localAnime.Episodes,
                 AverageScore = localAnime.AverageScore,
                 IsImported = true 
             })
            .ToList();

            var externalAnimeList = await _aniListClient.SearchAnimeAsync(request.query, cancellation);

            var externalResults = externalAnimeList.Select(externalAnime => new AnimeSearchResultDto
            {
                Id = null,
                AniListId = externalAnime.AniListId,
                Title = externalAnime.TitleEnglish ?? externalAnime.TitleRomaji,
                CoverImageUrl = externalAnime.CoverImageUrl,
                Format = externalAnime.Format,
                Status = externalAnime.Status,
                Episodes = externalAnime.Episodes,
                AverageScore = externalAnime.AverageScore,
                IsImported = false
            })
            .ToList();

            var externalOnlyResults = externalResults
                .Where (external => !localResults
                .Any(local => local.AniListId == external.AniListId))
                .ToList();

            return localResults
                .Concat(externalOnlyResults)
                .ToList();
        }
    }
}
