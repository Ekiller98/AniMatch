namespace AniMatch.Application.Common.Models.Battles
{
    public class BattleFeedItemDto
    {
        public int Id { get; set; }

        public string Prompt { get; set; } = string.Empty;

        public string? Category { get; set; }

        public BattleAnimeOptionDto AnimeA { get; set; } = null!;

        public BattleAnimeOptionDto AnimeB { get; set; } = null!;

        public DateTime CreatedAt { get; set; }
    }
}
