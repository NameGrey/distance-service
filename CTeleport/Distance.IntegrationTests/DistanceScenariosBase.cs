using System.IO;
using System.Reflection;
using Distance.API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

namespace Distance.FunctionalTests;

public class DistanceScenariosBase
{
    public TestServer CreateServer()
    {
        var path = Assembly.GetAssembly(typeof(DistanceScenariosBase))?.Location;

        var hostBuilder = new WebHostBuilder()
            .UseContentRoot(Path.GetDirectoryName(path) ?? string.Empty)
            .ConfigureAppConfiguration(cb =>
            {
                cb.AddJsonFile("appsettings.json", false)
                    .AddEnvironmentVariables();
            }).UseStartup<Startup>();

        return new TestServer(hostBuilder);
    }
}