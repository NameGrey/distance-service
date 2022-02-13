using Places.Client;

namespace Distance.API.Configuration
{
    public static class PlacesServiceClientExtensions
    {
        public static IServiceCollection ConfigurePlacesClientService(this IServiceCollection services, IConfiguration configuration)
        {
            var placesServiceOptions = configuration.GetSection("Places.API").Get<PlacesServiceOptions>();

            services.AddHttpClient<IPlacesServiceClient, PlacesServiceClient>(c =>
            {
                c.BaseAddress = new Uri(placesServiceOptions.Url);
                c.Timeout = placesServiceOptions.Timeout;
            });

            return services;
        }
    }
}
