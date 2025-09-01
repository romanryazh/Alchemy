using Alchemy.Domain.Interfaces;
using Alchemy.Domain.ValueObjects;
using MediatR;

namespace Alchemy.Application.Effects.Commands.UpdateEffect;

public class UpdateEffectCommandHandler(IEffectRepository effectRepository) : IRequestHandler<UpdateEffectCommand>
{
    public async Task Handle(UpdateEffectCommand request, CancellationToken ct)
    {
        // var effectId = new EffectId(request.Id);
        var effect = await effectRepository.GetByIdAsync(request.Id, ct);
        
        if (effect == null)
            throw new Exception($"Эффект с Id {request.Id} не найден.");

        effect.Update(request.Name, request.Description);
        await effectRepository.UpdateAsync(effect, ct);
    }
}