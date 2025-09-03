using Alchemy.Application.Components.DTOs;
using Alchemy.Application.Effects.DTOs;
using Alchemy.Application.Locations.DTOs;
using Alchemy.Domain.Interfaces;
using MediatR;

namespace Alchemy.Application.Components.Queries.GetComponent;

public class GetComponentByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetComponentByIdQuery, ComponentDto>
{
    public async Task<ComponentDto> Handle(GetComponentByIdQuery query, CancellationToken ct)
    {
        var component = await unitOfWork.ComponentRepository.GetByIdAsync(query.Id, ct);

        if (component == null)
            throw new NullReferenceException($"Компонент с Id {query.Id} не найден.");

        var effects = component.GetEffects();
        var effectDtos = effects.Select(e =>
            new EffectDto(e.Id.Value, e.Name, e.Description)).ToList();

        var locations = component.GetLocations();
        var locationDtos = locations.Select(e =>
            new LocationDto(e.Id.Value, e.Name, e.Description)).ToList();

        var componentDto = new ComponentDto(
            component.Id.Value, 
            component.Name, 
            component.Description, 
            component.Price,
            effectDtos, 
            locationDtos);
        
        return componentDto;
    }
}