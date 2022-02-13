using Distance.Business.Airports.Queries;
using Distance.Business.Common.Calculators;
using MediatR;
using Places.Client;
using Places.Client.Models;

namespace Distance.Business.Airports.QueryHandlers;

public class GetAirportsDistanceQueryHandler : IRequestHandler<GetAirportsDistanceQuery, int>
{
    private readonly IPlacesServiceClient _placesServiceClient;
    private readonly IDistanceCalculator _distanceCalculator;

    public GetAirportsDistanceQueryHandler(IPlacesServiceClient placesServiceClient, IDistanceCalculator distanceCalculator)
    {
        _placesServiceClient = placesServiceClient;
        _distanceCalculator = distanceCalculator;
    }

    public async Task<int> Handle(GetAirportsDistanceQuery request, CancellationToken cancellationToken)
    {
        var getFromAirportDetailsTask = _placesServiceClient.GetAirportDetails(request.FromAirportIata);
        var getToAirportDetailsTask = _placesServiceClient.GetAirportDetails(request.ToAirportIata);

        await Task.WhenAll(getFromAirportDetailsTask, getToAirportDetailsTask);

        var fromAirportDetails = getFromAirportDetailsTask.Result;
        var toAirportDetails = getToAirportDetailsTask.Result;

        return 0;
    }
}