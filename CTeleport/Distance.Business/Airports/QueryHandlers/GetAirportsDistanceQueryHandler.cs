using Distance.Business.Airports.Queries;
using MediatR;
using Places.Client;
using Places.Client.Models;

namespace Distance.Business.Airports.QueryHandlers;

public class GetAirportsDistanceQueryHandler : IRequestHandler<GetAirportsDistanceQuery, int>
{
    private readonly IPlacesServiceClient _placesServiceClient;

    public GetAirportsDistanceQueryHandler(IPlacesServiceClient placesServiceClient)
    {
        _placesServiceClient = placesServiceClient;
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