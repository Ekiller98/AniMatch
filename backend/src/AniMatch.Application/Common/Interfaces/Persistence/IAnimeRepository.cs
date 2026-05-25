using System;
using System.Collections.Generic;
using System.Text;
using AniMatch.Domain.Entities;

namespace AniMatch.Application.Common.Interfaces.Persistence
{
    public interface IAnimeRepository
    {
        Task<Anime?> GetByIdAsync (int id);
        Task<Anime?> GetByAniListIdAsync (int anilistid);
        Task <List<Anime>> SearchAsync (string query);
        Task AddAsync(Anime anime);
        Task SaveChangesAsync();


    }
}
