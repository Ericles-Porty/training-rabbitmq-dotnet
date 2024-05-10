using Eris.Rabbit.Store.Infra.Data.Repositories;

namespace Microsoft.Extensions.DependencyInjection;

public static class RepositoryDependenciesInjectionExtension
{
    public static IServiceCollection AddRepositoryDependencies(this IServiceCollection services)
    {
        services.AddScoped<PurchaseRepository>();
        services.AddScoped<ProductRepository>();
        return services;
    }
}