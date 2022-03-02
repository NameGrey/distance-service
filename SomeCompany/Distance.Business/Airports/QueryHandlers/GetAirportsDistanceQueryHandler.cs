using Distance.Business.Airports.Queries;
using Distance.Business.Common.Calculators;
using Distance.Domain.Models;
using Mapster;
using MediatR;
using Places.Client;

namespace Distance.Business.Airports.QueryHandlers;

public class GetAirportsDistanceQueryHandler : IRequestHandler<GetAirportsDistanceQuery, double>
{
    private readonly IPlacesServiceClient _placesServiceClient;
    private readonly IDistanceCalculator _distanceCalculator;

    public GetAirportsDistanceQueryHandler(IPlacesServiceClient placesServiceClient, IDistanceCalculator distanceCalculator)
    {
        _placesServiceClient = placesServiceClient;
        _distanceCalculator = distanceCalculator;
    }

    public async Task<double> Handle(GetAirportsDistanceQuery request, CancellationToken cancellationToken)
    {
        var getFromAirportDetailsTask = _placesServiceClient.GetAirportDetails(request.FromAirportIata);
        var getToAirportDetailsTask = _placesServiceClient.GetAirportDetails(request.ToAirportIata);

        await Task.WhenAll(getFromAirportDetailsTask, getToAirportDetailsTask);

        var fromAirportDetails = getFromAirportDetailsTask.Result;
        var toAirportDetails = getToAirportDetailsTask.Result;

        return _distanceCalculator.Calculate(fromAirportDetails.Adapt<LocationCoordinate>(), toAirportDetails.Adapt<LocationCoordinate>());
    }
}