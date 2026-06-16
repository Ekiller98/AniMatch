using AniMatch.Application.Common.Models.Anime;

namespace AniMatch.Application.Common.Interfaces.Infrastructure
{
    public interface IAniListClient
    {
        Task<List<AniListAnimeDto>> SearchAnimeAsync(string query, CancellationToken cancellation);

        Task<AniListAnimeDto?> GetAnimeByIdAsync(int aniListId, CancellationToken cancellation);
    }
}
