using AniMatch.Application.Common.Interfaces.Persistence;
using AniMatch.Application.Common.Models.Anime;
using MediatR;

namespace AniMatch.Application.Features.Anime.Queries.GetAnimeById
{
    public class GetAnimeByIdQueryHandler : IRequestHandler<GetAnimeByIdQuery, AnimeDetailsDto?>
    {
        private readonly IAnimeRepository _animeRepository;

        public GetAnimeByIdQueryHandler(IAnimeRepository animeRepository)
        {
            _animeRepository = animeRepository;
        }

        public async Task<AnimeDetailsDto?> Handle(GetAnimeByIdQuery request, CancellationToken cancellation)
        {
            var anime = await _animeRepository.GetByIdAsync(request.Id, cancellation);

            if (anime == null)
            {
                return null;
            }

            return new AnimeDetailsDto
            {
                Id = anime.Id,
                AniListId = anime.AniListId,
                Title = anime.TitleEnglish ?? anime.TitleRomaji,
                Description = anime.Description,
                CoverImageUrl = anime.CoverImageUrl,
                BannerImageUrl = anime.BannerImageUrl,
                Format = anime.Format,
                Status = anime.Status,
                Episodes = anime.Episodes,
                AverageScore = anime.AverageScore,
                Popularity = anime.Popularity
            };
        }
    }
}
