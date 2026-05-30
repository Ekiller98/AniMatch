using AniMatch.Domain.Entities;

namespace AniMatch.Application.Common.Interfaces.Persistence
{
    public interface IAnimeRepository
    {
        Task<Anime?> GetByIdAsync (int id, CancellationToken cancellation);
        Task<Anime?> GetByAniListIdAsync (int anilistid, CancellationToken cancellation);
        Task <List<Anime>> SearchAsync (string query, CancellationToken cancellation);
        Task AddAsync(Anime anime, CancellationToken cancellation);
        Task SaveChangesAsync(CancellationToken cancellation);


    }
}
