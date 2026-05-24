using System;
using Microsoft.EntityFrameworkCore;

namespace AniMatch.Persistence.Context;

public class AniMatchDbContext : DbContext
{
	public AniMatchDbContext(DbContextOptions<AniMatchDbContext> options)
		:base(options)
	{
	}
}
