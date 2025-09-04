using Alchemy.Application.Components.DTOs;
using Alchemy.Application.CraftSteps.DTOs;
using Alchemy.Application.Effects.DTOs;
using Alchemy.Application.Locations.DTOs;
using Alchemy.Domain.Interfaces;
using MediatR;

namespace Alchemy.Application.CraftSteps.Queries.GetCraftComponent;

public class GetCraftStepByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetCraftStepByIdQuery, CraftStepDto>
{
    public async Task<CraftStepDto> Handle(GetCraftStepByIdQuery request, CancellationToken cancellationToken)
    {
        var step = await unitOfWork.CraftStepRepository.GetByIdAsync(request.Id, cancellationToken);
        
        if (step == null)
        {
            throw new NullReferenceException($"Шаг создания с Id {request.Id} не найден.");
        }

        var componentDtos = step
            .GetComponents()
            .Select(c =>
            new ComponentDto(c.Id.Value, c.Name, c.Description, c.Price, 
                c.GetEffects().Select(e => 
                    new EffectDto(e.Id.Value, e.Name, e.Description)).ToList(), 
                c.GetLocations().Select(l => 
                    new LocationDto(l.Id.Value, l.Name, l.Description)).ToList())).ToList();
        
        var stepDto = new CraftStepDto(step.Id.Value, step.Name, step.Description, step.Order, componentDtos);
        return stepDto;
    }
}