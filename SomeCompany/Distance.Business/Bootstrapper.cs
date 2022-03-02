using Distance.Business.Common.Calculators;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Distance.Business;

public static class Bootstrapper
{
    public static void BootstrapBusiness(this IServiceCollection services)
    {
        services.AddTransient<IDistanceCalculator, DistanceCalculator>();
        services.AddMediatR(typeof(Bootstrapper));

        Common.Maps.Bootstrapper.InitializeMaps();
    }
}