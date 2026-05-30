namespace AniMatch.Domain.Entities
{
    public class Anime
    {
        public int Id { get; set; }

        public int AniListId { get; set; }
        
        public string TitleEnglish { get; set; } = string.Empty;
        
        public string TitleRomaji { get; set; } = string.Empty;

        public string? TitleNative { get; set; }
        
        public string? Description { get; set; }
        
        public string? CoverImageUrl { get; set; }
        
        public string? BannerImageUrl { get; set; }
        
        public string ? Format { get; set; }
        
        public string? Status { get; set; }
        
        public int? SeasonYear { get; set; }
        
        public int? Episodes { get; set; }
        
        public int? AverageScore { get; set; }
        
        public int? Popularity { get; set; }
        
        public int IsAdult { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime UpdatedAt { get; set; }
        
        public DateTime? LastSyncedAt { get; set; }
    }
}
