using Alchemy.Application.Effects.DTOs;
using Alchemy.Application.Potions.DTOs;
using Alchemy.Domain.Interfaces;
using MediatR;

namespace Alchemy.Application.Potions.Queries.GetPotion;

public class GetPotionByIdQueryHandler(IPotionRepository potionRepository)
    : IRequestHandler<GetPotionByIdQuery, PotionDto>
{
    public async Task<PotionDto> Handle(GetPotionByIdQuery query, CancellationToken ct)
    {
        var potion = await potionRepository.GetByIdAsync(query.Id, ct);

        if (potion == null)
        {
            throw new NullReferenceException($"Эффект с Id {query.Id} не найден.");
        }

        var effectDtos = potion.GetEffects()
            .Select(e => new EffectDto(e.Id.Value, e.Name, e.Description))
            .ToList();
        
        var potionDto = new PotionDto(potion.Id.Value, potion.Name, potion.Description, effectDtos);
        return potionDto;
    }
}