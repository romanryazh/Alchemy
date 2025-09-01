using Alchemy.Application.Locations.DTOs;
using MediatR;

namespace Alchemy.Application.Locations.Queries.GetLocation;

public record GetLocationByIdQuery(Guid Id) : IRequest<LocationDto>;