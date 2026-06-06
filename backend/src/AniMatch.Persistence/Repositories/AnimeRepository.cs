using AniMatch.Application.Common.Interfaces.Persistence;
using AniMatch.Domain.Entities;
using AniMatch.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace AniMatch.Persistence.Repositories
{
    public class AnimeRepository : IAnimeRepository
    {
        private readonly AniMatchDbContext _dbContext;

        public AnimeRepository(AniMatchDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<Anime?> GetByIdAsync(int id, CancellationToken cancellation) 
        {
            return await _dbContext.Anime
            .FirstOrDefaultAsync(anime => anime.Id == id);
        }
        public async Task<Anime?> GetByAniListIdAsync(int anilistid, CancellationToken cancellation)
        {
            return await _dbContext.Anime
                .FirstOrDefaultAsync(anime => anime.AniListId == anilistid);
        }
        public async Task<List<Anime>> SearchAsync(string query, CancellationToken cancellation)
        {
            var searchPattern = $"%{query}%";

            return await _dbContext.Anime
                .Where(anime =>
                    EF.Functions.ILike(anime.TitleRomaji, searchPattern) || 
                    anime.TitleEnglish != null && 
                    EF.Functions.ILike(anime.TitleEnglish, searchPattern ))
                .ToListAsync();
        }
        public async Task AddAsync(Anime anime, CancellationToken cancellation)
        {
            await _dbContext.Anime.AddAsync(anime);
        }
        public async Task SaveChangesAsync(CancellationToken cancellation)
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
