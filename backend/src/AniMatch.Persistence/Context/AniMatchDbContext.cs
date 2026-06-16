using Microsoft.EntityFrameworkCore;
using AniMatch.Domain.Entities;

namespace AniMatch.Persistence.Context;

public class AniMatchDbContext : DbContext
{
	public AniMatchDbContext(DbContextOptions<AniMatchDbContext> options)
		: base(options)
	{
	}
	public DbSet<Anime> Anime { get; set; }
    public DbSet<Battle> Battles { get; set; }
    public DbSet<BattlePrompt> BattlePrompts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Battle>()
            .HasOne(b => b.AnimeA)
            .WithMany()
            .HasForeignKey(b => b.AnimeAId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Battle>()
            .HasOne(b => b.AnimeB)
            .WithMany()
            .HasForeignKey(b => b.AnimeBId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Battle>()
            .HasOne(b => b.Prompt)
            .WithMany()
            .HasForeignKey(b => b.BattlePromptId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
