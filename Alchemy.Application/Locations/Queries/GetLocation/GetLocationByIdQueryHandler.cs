using Alchemy.Application.Common.Exceptions;
using Alchemy.Application.Locations.DTOs;
using Alchemy.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace Alchemy.Application.Locations.Queries.GetLocation;

public class GetLocationByIdQueryHandler(ILocationRepository locationRepository, IMapper mapper) : IRequestHandler<GetLocationByIdQuery, LocationDto>
{
    public async Task<LocationDto> Handle(GetLocationByIdQuery query, CancellationToken ct)
    {
        var location = await locationRepository.GetByIdAsync(query.Id, ct);

        if (location == null)
        {
            throw new Exception($"Локация с Id {query.Id} не найдена.");
        }
        
        // var locationDto = new LocationDto(location.Id.Value, location.Name, location.Description);
        var locationDto = mapper.Map<LocationDto>(location);
        return locationDto;
    }
}