using Alchemy.Application.Effects.DTOs;
using Alchemy.Domain.Interfaces;
using Alchemy.Domain.ValueObjects;
using MediatR;

namespace Alchemy.Application.Effects.Queries.GetEffect;

public class GetEffectByIdQueryHandler(IEffectRepository effectRepository) : IRequestHandler<GetEffectByIdQuery, EffectDto>
{
    public async Task<EffectDto> Handle(GetEffectByIdQuery query, CancellationToken ct)
    {
        // var effectId = new EffectId(query.Id);
        var effect = await effectRepository.GetByIdAsync(query.Id, ct);

        if (effect == null)
            throw new Exception($"Эффект с Id {query.Id} не найден.");
        
        return new EffectDto(effect.Id.Value, effect.Name, effect.Description);
    }
}