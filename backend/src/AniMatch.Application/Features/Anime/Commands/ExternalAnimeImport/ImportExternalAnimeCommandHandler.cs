using AniMatch.Application.Common.Interfaces.Infrastructure;
using AniMatch.Application.Common.Interfaces.Persistence;
using AniMatch.Application.Common.Models;
using AnimeEntity = AniMatch.Domain.Entities.Anime;
using MediatR;

namespace AniMatch.Application.Features.Anime.Commands.ExternalAnimeImport
{
    public class ImportExternalAnimeCommandHandler : IRequestHandler<ImportExternalAnimeCommand, AnimeDetailsDto?>
    {
        private readonly IAnimeRepository _animeRepository;
        private readonly IAniListClient _aniListClient;

        public ImportExternalAnimeCommandHandler(IAnimeRepository animeRepository, IAniListClient aniListClient)
        {
            _animeRepository = animeRepository;
            _aniListClient = aniListClient;
        }

        public async Task<AnimeDetailsDto?> Handle(ImportExternalAnimeCommand request, CancellationToken cancellation)
        {
            var anime = await _animeRepository.GetByAniListIdAsync(request.aniListId, cancellation);

            if (anime != null)
            {
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

            var aniListAnime = await _aniListClient.GetAnimeByIdAsync(request.aniListId, cancellation);

            if (aniListAnime == null)
            {
                return null; 
            }

            var animeToBeStored = new AnimeEntity
            {
                AniListId = aniListAnime.AniListId,
                TitleRomaji = aniListAnime.TitleRomaji,
                TitleEnglish = aniListAnime.TitleEnglish,
                TitleNative = aniListAnime.TitleNative,
                Description = aniListAnime.Description,
                CoverImageUrl = aniListAnime.CoverImageUrl,
                BannerImageUrl = aniListAnime.BannerImageUrl,
                Format = aniListAnime.Format,
                Status = aniListAnime.Status,
                SeasonYear = aniListAnime.SeasonYear,
                Episodes = aniListAnime.Episodes,
                AverageScore = aniListAnime.AverageScore,
                Popularity = aniListAnime.Popularity,
                IsAdult = aniListAnime.IsAdult
            };

            await _animeRepository.AddAsync(animeToBeStored, cancellation);

            await _animeRepository.SaveChangesAsync(cancellation);

            return new AnimeDetailsDto
            {
                Id = animeToBeStored.Id,
                AniListId = animeToBeStored.AniListId,
                Title = animeToBeStored.TitleEnglish ?? animeToBeStored.TitleRomaji,
                Description = animeToBeStored.Description,
                CoverImageUrl = animeToBeStored.CoverImageUrl,
                BannerImageUrl = animeToBeStored.BannerImageUrl,
                Format = animeToBeStored.Format,
                Status = animeToBeStored.Status,
                Episodes = animeToBeStored.Episodes,
                AverageScore = animeToBeStored.AverageScore,
                Popularity = animeToBeStored.Popularity
            };
        }
    }
}
