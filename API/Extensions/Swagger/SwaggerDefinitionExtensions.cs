namespace Microsoft.Extensions.DependencyInjection;

public static class SwaggerDefinitionExtensions
{
    public static IServiceCollection AddSwaggerDefinition(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new()
            {
                Title = "Eris.Rabbit.API",
                Version = "v1",
            });

            var filePath = Path.Combine(AppContext.BaseDirectory, "API.xml");
            Console.WriteLine(filePath);
            c.IncludeXmlComments(filePath);
        });

        return services;
    }
}