using Alchemy.Domain.Entities;
using Alchemy.Domain.ValueObjects;
using AutoMapper;

namespace Alchemy.Application.Locations.DTOs;

public class LocationProfile : Profile
{
    public LocationProfile()
    {
        CreateMap<LocationId, Guid>().ConvertUsing(src => src.Value);
        CreateMap<Guid, LocationId>().ConvertUsing(g => new LocationId(g));
        
        
        CreateMap<Location, LocationDto>()
            .ForMember(
                dto => dto.Id,
                opt => opt.MapFrom(src => src.Id.Value))
            .ReverseMap()
            .ForMember(
                e => e.Id,
                opt => opt.MapFrom(dto => new LocationId(dto.Id)));
    }
}