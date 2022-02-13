using Distance.API.Configuration;
using Distance.API.Swagger;
using System.Reflection;

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
        services.ConfigurePlacesClientService(_configuration);

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

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });

        app.ConfigureSwagger(SwaggerVersion, SwaggerTitle);
    }
}