using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Distance.Business;

public static class Bootstrapper
{
    public static void BootstrapBusiness(this IServiceCollection services)
    {
        services.AddMediatR(typeof(Bootstrapper));
    }
}