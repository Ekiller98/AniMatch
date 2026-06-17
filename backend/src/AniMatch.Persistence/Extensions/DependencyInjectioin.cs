using AniMatch.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AniMatch.Application.Common.Interfaces.Persistence;
using AniMatch.Persistence.Repositories;
using AniMatch.Persistence.Identity;

namespace AniMatch.Persistence.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<AniMatchDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"))
                .UseSnakeCaseNamingConvention());

        services.AddIdentityCore<ApplicationUser>()
            .AddEntityFrameworkStores<AniMatchDbContext>();

        services.AddScoped<IAnimeRepository, AnimeRepository>();

        services.AddScoped<IBattleRepository, BattleRepository>();

        return services;
    }
}
