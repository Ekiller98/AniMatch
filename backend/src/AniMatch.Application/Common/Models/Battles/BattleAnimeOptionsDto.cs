namespace AniMatch.Application.Common.Models.Battles
{
    public class BattleAnimeOptionDto
    {
        public int Id { get; set; }

        public int AniListId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? CoverImageUrl { get; set; }

    }
}
