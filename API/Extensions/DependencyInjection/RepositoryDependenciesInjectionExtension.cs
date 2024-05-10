using Protech.Animes.Domain.Interfaces.Repositories;
using Protech.Animes.Infrastructure.Data.Repositories;

namespace Protech.Animes.API.Extensions.DependencyInjection;

public static class RepositoryDependenciesInjectionExtension
{
    public static IServiceCollection AddRepositoryDependencies(this IServiceCollection services)
    {
        services.AddScoped<IDirectorRepository, DirectorRepository>();
        services.AddScoped<IAnimeRepository, AnimeRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}