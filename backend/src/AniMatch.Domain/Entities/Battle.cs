namespace AniMatch.Domain.Entities
{
    public class Battle
    {
        public int Id { get; set; }

        public int AnimeAId { get; set; }

        public int AnimeBId { get; set; }

        public int BattlePromptId { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Anime AnimeA { get; set; } = null!;

        public Anime AnimeB { get; set; } = null!;

        public BattlePrompt Prompt { get; set; } = null!;
    }
}
