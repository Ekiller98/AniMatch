using MediatR;
using AniMatch.Application.Common.Interfaces.Persistence;

namespace AniMatch.Application.Features.Anime.Queries.SearchAnime
{
    public class SearchAnimeQueryHandler : IRequestHandler<SearchAnimeQuery, List<AnimeSearchResultDto>>
    {
        private readonly IAnimeRepository _animerepository;

        public SearchAnimeQueryHandler(IAnimeRepository animeRepository) 
        {
            _animerepository = animeRepository;
        }

        public async Task<List<AnimeSearchResultDto>> Handle(SearchAnimeQuery request, CancellationToken cancellation)
        {
            var animeList = await _animerepository.SearchAsync(request.query, cancellation);

            return animeList.Select(Anime => new AnimeSearchResultDto
             {
                 Id = Anime.Id,
                 Title = Anime.TitleEnglish ?? Anime.TitleRomaji,
                 CoverImageUrl = Anime.CoverImageUrl,
                 Format = Anime.Format,
                 Status = Anime.Status,
                 Episodes = Anime.Episodes,
                 AverageScore = Anime.AverageScore
             })
            .ToList();
        }
    }
}
