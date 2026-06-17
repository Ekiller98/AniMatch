using AniMatch.Domain.Entities;
using AniMatch.Persistence.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AniMatch.Persistence.Context;

public class AniMatchDbContext : IdentityDbContext<ApplicationUser>
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

        modelBuilder.Entity<ApplicationUser>().ToTable("users");
        modelBuilder.Entity<IdentityRole>().ToTable("roles");
        modelBuilder.Entity<IdentityUserRole<string>>().ToTable("user_roles");
        modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("user_claims");
        modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("user_logins");
        modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("role_claims");
        modelBuilder.Entity<IdentityUserToken<string>>().ToTable("user_tokens");
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
