using Distance.Business.Airports.Queries;
using MediatR;

namespace Distance.Business.Airports.QueryHandlers;

public class GetAirportsDistanceQueryHandler : IRequestHandler<GetAirportsDistanceQuery, int>
{
    public Task<int> Handle(GetAirportsDistanceQuery request, CancellationToken cancellationToken)
    {
        // todo: Implement business logic
        return Task.FromResult(0);
    }
}