using AniMatch.Application.Common.Interfaces.Infrastructure;
using AniMatch.Application.Common.Models;
using System.Net.Http.Json;

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
            var graphQlQuery = """
            query ($search: String) {
              Page(page: 1, perPage: 10) {
                media(search: $search, type: ANIME) {
                  id
                  title {
                    romaji
                    english
                    native
                  }
                  description
                  coverImage {
                    large
                  }
                  bannerImage
                  format
                  status
                  seasonYear
                  episodes
                  averageScore
                  popularity
                  isAdult
                }
              }
            }
            """;

            var requestBody = new
            {
                query = graphQlQuery,
                variables = new
                {
                    search = query
                }
            };

            var aniListJsonResponse = await _httpClient.PostAsJsonAsync("https://graphql.anilist.co", requestBody, cancellation);

            aniListJsonResponse.EnsureSuccessStatusCode();

            var AniListGraphQlResponse = await aniListJsonResponse.Content.ReadFromJsonAsync<AniListGraphQlResponse>(cancellation);

            var media = AniListGraphQlResponse?.Data?.Page?.Media ?? [];

            return media.Select(anime => new AniListAnimeDto
                {
                    AniListId = anime.Id,
                    TitleRomaji = anime.Title?.Romaji ?? string.Empty,
                    TitleEnglish = anime.Title?.English ,
                    TitleNative = anime.Title?.Native,
                    Description = anime.Description,
                    CoverImageUrl = anime.CoverImage?.Large,
                    BannerImageUrl = anime.BannerImage,
                    Format = anime.Format,
                    Status = anime.Status,
                    SeasonYear = anime.SeasonYear,
                    Episodes = anime.Episodes,
                    AverageScore = anime.AverageScore,
                    Popularity = anime.Popularity,
                    IsAdult = anime.IsAdult
                })
                .ToList();
        }
        public async Task<AniListAnimeDto?> GetAnimeByIdAsync(int aniListId, CancellationToken cancellation)
        {
            var graphQlQuery = """
            query ($id: Int!) {
              Media(id: $id, type: ANIME) {
                id
                title {
                  romaji
                  english
                  native
                }
                description
                coverImage {
                  large
                }
                bannerImage
                format
                status
                seasonYear
                episodes
                averageScore
                popularity
                isAdult
              }
            }
            """;

            var requestBody = new
            {
                query = graphQlQuery,
                variables = new
                {
                    id = aniListId
                }
            };

            var aniListJsonResponse = await _httpClient.PostAsJsonAsync("https://graphql.anilist.co", requestBody, cancellation);

            aniListJsonResponse.EnsureSuccessStatusCode();

            var aniListSingleGraphQlResponse = await aniListJsonResponse.Content.ReadFromJsonAsync<AniListSingleGraphQlResponse>(cancellation);

            var media = aniListSingleGraphQlResponse?.Data?.Media;

            if (media == null)
            {
                return null;
            }
            return new AniListAnimeDto
            {
                AniListId = media.Id,
                TitleRomaji = media.Title?.Romaji ?? string.Empty,
                TitleEnglish = media.Title?.English,
                TitleNative = media.Title?.Native,
                Description = media.Description,
                CoverImageUrl = media.CoverImage?.Large,
                BannerImageUrl = media.BannerImage,
                Format = media.Format,
                Status = media.Status,
                SeasonYear = media.SeasonYear,
                Episodes = media.Episodes,
                AverageScore = media.AverageScore,
                Popularity = media.Popularity,
                IsAdult = media.IsAdult
            };
        }
        private class AniListSingleGraphQlResponse
        {
            public AniListSingleDataResponse? Data { get; set; }
        }

        private class AniListSingleDataResponse
        {
            public AniListMediaResponse? Media { get; set; }
        }

        private class AniListGraphQlResponse
        {
            public AniListDataResponse? Data { get; set; }
        }

        private class AniListDataResponse
        {
            public AniListPageResponse? Page { get; set; }
        }

        private class AniListPageResponse
        {
            public List<AniListMediaResponse> Media { get; set; } = [];
        }

        private class AniListMediaResponse
        {
            public int Id { get; set; }

            public AniListTitleResponse? Title { get; set; }

            public string? Description { get; set; }

            public AniListCoverImageResponse? CoverImage { get; set; }

            public string? BannerImage { get; set; }

            public string? Format { get; set; }

            public string? Status { get; set; }

            public int? SeasonYear { get; set; }

            public int? Episodes { get; set; }

            public int? AverageScore { get; set; }

            public int? Popularity { get; set; }

            public bool IsAdult { get; set; }
        }

        private class AniListTitleResponse
        {
            public string? Romaji { get; set; }

            public string? English { get; set; }

            public string? Native { get; set; }
        }

        private class AniListCoverImageResponse
        {
            public string? Large { get; set; }
        }
    }
}
