using AniMatch.Domain.Entities;

namespace AniMatch.Application.Common.Interfaces.Persistence
{
    public interface IBattleRepository
    {
        Task<List<Battle>> GetActiveBattlesAsync(CancellationToken cancellation);
    }
}
