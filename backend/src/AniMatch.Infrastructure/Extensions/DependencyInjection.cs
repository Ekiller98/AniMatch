using Microsoft.Extensions.DependencyInjection;
using AniMatch.Application.Common.Interfaces.Infrastructure;
using AniMatch.Infrastructure.External.AniList;
using Microsoft.Extensions.Configuration;



namespace AniMatch.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IAniListClient, AniListClient>();

            return services;
        }
    }
}
