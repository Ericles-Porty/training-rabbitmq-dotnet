using Microsoft.AspNetCore.RateLimiting;
using Eris.Rabbit.Store.Domain.Policies;
namespace Microsoft.Extensions.DependencyInjection;

public static class RateLimitExtension
{
    public static IServiceCollection AddRateLimiter(this IServiceCollection services)
    {
        services.AddRateLimiter(
            options =>
            {
                options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

                options.AddFixedWindowLimiter(
                    policyName: RateLimitPolicies.Fixed,
                    configureOptions: rateLimitOptions =>
                    {
                        rateLimitOptions.PermitLimit = 100;
                        rateLimitOptions.Window = TimeSpan.FromMinutes(10);
                    }
                );
            }
        );

        return services;
    }
}