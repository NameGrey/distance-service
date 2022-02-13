using Distance.Business.Common.Extensions;
using Distance.Business.Common.Models;

namespace Distance.Business.Common.Calculators;

public class DistanceCalculator : IDistanceCalculator
{
    private const double EarthRadiusInMiles = 3956;

    public double Calculate(LocationCoordinate from, LocationCoordinate to)
    {
        var lonFromInRadians = from.Longitude.ToRadians();
        var lonToInRadians = to.Longitude.ToRadians();
        var latFromInRadians = from.Latitude.ToRadians();
        var latToInRadians = to.Latitude.ToRadians();

        // Haversine formula
        var difLon = lonToInRadians - lonFromInRadians;
        var difLat = latToInRadians - latFromInRadians;
        var a = Math.Pow(Math.Sin(difLat / 2), 2) +
                Math.Cos(latFromInRadians) * Math.Cos(latToInRadians) *
                Math.Pow(Math.Sin(difLon / 2), 2);

        var c = 2 * Math.Asin(Math.Sqrt(a));

        return c * EarthRadiusInMiles;
    }
}