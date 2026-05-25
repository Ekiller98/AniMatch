using System;
using Microsoft.EntityFrameworkCore;
using AniMatch.Domain.Entities;

namespace AniMatch.Persistence.Context;

public class AniMatchDbContext : DbContext
{
	public AniMatchDbContext(DbContextOptions<AniMatchDbContext> options)
		:base(options)
	{
	}
	public DbSet<Anime> Anime { get; set; }
}
