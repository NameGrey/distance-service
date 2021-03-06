using Distance.API.Extensions;
using Distance.Business;
using System.Reflection;
using AspNetCoreRateLimit;

namespace Distance.API;

public class Startup
{
    private const string SwaggerVersion = "v2";
    private const string SwaggerTitle = "Distance API";

    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.ConfigureSwagger(SwaggerVersion, SwaggerTitle, Assembly.GetExecutingAssembly().GetName().Name!);
        services.ConfigureRateLimitMiddleware(_configuration);
        services.ConfigurePlacesClientService(_configuration);

        services.BootstrapBusiness();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseHttpsRedirection();
            app.UseHsts();
        }

        app.UseRouting();
        app.UseIpRateLimiting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });

        app.ConfigureSwagger(SwaggerVersion, SwaggerTitle);
    }
}