namespace AniMatch.Application.Common.Models
{
    public class AnimeDetailsDto
    {
        public int Id { get; set; }

        public int AniListId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? CoverImageUrl { get; set; }

        public string? BannerImageUrl { get; set; }

        public string? Format { get; set; }

        public string? Status { get; set; }

        public int? Episodes { get; set; }

        public int? AverageScore { get; set; }

        public int? Popularity { get; set; }
    }
}
