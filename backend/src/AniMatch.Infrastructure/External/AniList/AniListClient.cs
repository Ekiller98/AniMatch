using AniMatch.Application.Common.Interfaces.Infrastructure;
using AniMatch.Application.Common.Models;

namespace AniMatch.Infrastructure.External.AniList
{
    public class AniListClient : IAniListClient
    {
        private readonly HttpClient _httpClient;

        public AniListClient(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        public async Task<List<AniListAnimeDto>> SearchAnimeAsync(string query, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
