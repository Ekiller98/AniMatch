using AniMatch.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AniMatch.Application.Common.Interfaces.Persistence;
using AniMatch.Persistence.Repositories;
using AniMatch.Persistence.Identity;
using AniMatch.Persistence.Auth;
using AniMatch.Application.Common.Interfaces.Auth;

namespace AniMatch.Persistence.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<AniMatchDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"))
                .UseSnakeCaseNamingConvention());

        services.AddIdentityCore<ApplicationUser>(options =>
        {
            options.Password.RequiredLength = 8;
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = false;

            options.User.RequireUniqueEmail = true;
        })
            .AddEntityFrameworkStores<AniMatchDbContext>();

        services.AddScoped<IAnimeRepository, AnimeRepository>();

        services.AddScoped<IBattleRepository, BattleRepository>();

        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}
