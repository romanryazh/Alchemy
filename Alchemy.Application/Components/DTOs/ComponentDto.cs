using Alchemy.Application.Effects.DTOs;
using Alchemy.Application.Locations.DTOs;

namespace Alchemy.Application.Components.DTOs;

public record ComponentDto(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    List<EffectDto> Effects,
    List<LocationDto> Locations);