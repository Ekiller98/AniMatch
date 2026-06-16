using AniMatch.Application.Common.Interfaces.Persistence;
using AniMatch.Domain.Entities;
using AniMatch.Persistence.Context;
using Microsoft.EntityFrameworkCore;



namespace AniMatch.Persistence.Repositories
{
    public class BattleRepository : IBattleRepository
    {
        private readonly AniMatchDbContext _aniMatchDbContext;

        public BattleRepository(AniMatchDbContext aniMatchDbContext)
        {
            _aniMatchDbContext = aniMatchDbContext;
        }

        public async Task<List<Battle>> GetActiveBattlesAsync(CancellationToken cancellation)
        {
            return await _aniMatchDbContext.Battles
                .Where(battle => battle.IsActive)
                .Include(battle => battle.AnimeA)
                .Include(battle => battle.AnimeB)
                .Include(battle => battle.Prompt)
                .OrderByDescending(battle => battle.CreatedAt)
                .ToListAsync(cancellation);
        }
    }
}
