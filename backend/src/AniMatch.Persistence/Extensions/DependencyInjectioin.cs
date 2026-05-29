using System;
using AniMatch.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AniMatch.Application.Common.Interfaces.Persistence;
using AniMatch.Persistence.Repositories;

namespace AniMatch.Persistence.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AniMatchDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"))
                .UseSnakeCaseNamingConvention());

        services.AddScoped<IAnimeRepository, AnimeRepository>();

        return services;
    }
}
