using Distance.Domain.Models;

namespace Distance.Business.Common.Calculators;

public interface IDistanceCalculator
{
    double Calculate(LocationCoordinate from, LocationCoordinate to);
}