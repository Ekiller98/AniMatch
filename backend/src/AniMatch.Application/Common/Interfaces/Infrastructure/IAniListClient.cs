using AniMatch.Application.Common.Models;

namespace AniMatch.Application.Common.Interfaces.Infrastructure
{
    public interface IAniListClient
    {
        Task<List<AniListAnimeDto>> SearchAnimeAsync(string query, CancellationToken cancellation);
    }
}
