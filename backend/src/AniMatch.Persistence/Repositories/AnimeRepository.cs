using System;
using System.Collections.Generic;
using System.Text;
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

        public async Task<Anime?> GetByIdAsync(int id) 
        {
            return await _dbContext.Anime
            .FirstOrDefaultAsync(anime => anime.Id == id);
        }
        public async Task<Anime?> GetByAniListIdAsync(int anilistid)
        {
            return await _dbContext.Anime
                .FirstOrDefaultAsync(anime => anime.AniListId == anilistid);
        }
        public async Task<List<Anime>> SearchAsync(string query)
        {
            return await _dbContext.Anime
                .Where(anime =>
                    anime.TitleRomaji.Contains(query) ||
                    anime.TitleEnglish != null && anime.TitleEnglish.Contains(query))
                .ToListAsync();
        }
        public async Task AddAsync(Anime anime)
        {
            await _dbContext.Anime.AddAsync(anime);
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
