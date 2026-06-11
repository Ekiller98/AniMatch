namespace AniMatch.Application.Common.Models
{
    public class AnimeSearchResultDto
    {
        public int? Id { get; set; }

        public int AniListId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? CoverImageUrl { get; set; }

        public string? Format { get; set; }

        public string? Status { get; set; }
        
        public int? Episodes { get; set; }

        public int? AverageScore { get; set; }

        public bool IsImported { get; set; }
    }
}
