using System.Reflection;
using Distance.API.Swagger;

namespace Distance.API;

public class Startup
{
    private const string SwaggerVersion = "v2";
    private const string SwaggerTitle = "Distance API";

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.ConfigureSwagger(SwaggerVersion, SwaggerTitle, Assembly.GetExecutingAssembly().GetName().Name!);
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