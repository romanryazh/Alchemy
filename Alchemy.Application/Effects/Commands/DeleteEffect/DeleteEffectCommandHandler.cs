using Alchemy.Domain.Interfaces;
using Alchemy.Domain.ValueObjects;
using MediatR;

namespace Alchemy.Application.Effects.Commands.DeleteEffect;

public class DeleteEffectCommandHandler(IEffectRepository effectRepository) : IRequestHandler<DeleteEffectCommand>
{
    public async Task Handle(DeleteEffectCommand request, CancellationToken ct)
    {
        // var effectId = new EffectId(request.Id);
        var effect = await effectRepository.GetByIdAsync(request.Id, ct);

        if (effect == null)
            throw new Exception($"Эффект с Id {request.Id} не найден.");
        
        await effectRepository.DeleteAsync(effect, ct);
    }
}