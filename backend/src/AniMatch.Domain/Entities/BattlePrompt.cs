namespace AniMatch.Domain.Entities
{
    public class BattlePrompt
    {
        public int Id { get; set; }

        public string Description { get; set; } = string.Empty;

        public string? Category { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
