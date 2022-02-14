using AspNetCoreRateLimit;

namespace Distance.API.Extensions;

public static class RateLimitMiddlewareExtensions
{
    public static IServiceCollection ConfigureRateLimitMiddleware(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions();
        services.AddMemoryCache();
        services.Configure<IpRateLimitOptions>(configuration.GetSection("IpRateLimiting"));
        services.Configure<IpRateLimitPolicies>(configuration.GetSection("IpRateLimitPolicies"));

        services.AddInMemoryRateLimiting();
        services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

        return services;
    }
}