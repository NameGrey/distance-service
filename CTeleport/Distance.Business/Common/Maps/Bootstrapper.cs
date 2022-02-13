using Mapster;

namespace Distance.Business.Common.Maps;

public static class Bootstrapper
{
    public static void InitializeMaps()
    {
        TypeAdapterConfig.GlobalSettings.Scan(typeof(Business.Bootstrapper).Assembly);
    }
}