using Distance.Business.Common.Models;
using Mapster;
using Places.Client.Models;

namespace Distance.Business.Common.Maps;

public class LocationCoordinateMap : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AirportDetails, LocationCoordinate>()
            .Map(dest => dest.Longitude, src => src.Location.Longitude)
            .Map(dest => dest.Latitude, src => src.Location.Latitude);
    }
}