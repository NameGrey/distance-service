using MediatR;

namespace Distance.Business.Airports.Queries;

public record GetAirportsDistanceQuery(string FromAirportIata, string ToAirportIata) : IRequest<double>;
