using Protech.Animes.Application.Services;
using Protech.Animes.Domain.Interfaces.Services;

namespace Protech.Animes.API.Extensions.DependencyInjection;
public static class ServicesDependenciesInjectionExtension
{
    public static IServiceCollection AddServicesDependencies(this IServiceCollection services)
    {
        services.AddScoped<IAnimeService, AnimeService>();
        services.AddScoped<IDirectorService, DirectorService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IJwtTokenService, JwtTokenService>();
        services.AddScoped<ICryptographyService, CryptographyService>();

        return services;
    }
}