namespace AniMatch.Application.Features.Anime.Queries.SearchAnime
{
    public class AnimeSearchResultDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? CoverImageUrl { get; set; }

        public string? Format { get; set; }

        public string? Status { get; set; }
        
        public int? Episodes { get; set; }

        public int? AverageScore { get; set; }
    }
}
