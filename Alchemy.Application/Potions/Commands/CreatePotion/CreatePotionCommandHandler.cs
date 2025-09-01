using Alchemy.Application.Common.Exceptions;
using Alchemy.Domain.Entities;
using Alchemy.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace Alchemy.Application.Potions.Commands.CreatePotion;

public class CreatePotionCommandHandler(
    IPotionRepository potionRepository,
    IEffectRepository effectRepository,
    IUniqueCheckerService checker, 
    IValidator<CreatePotionCommand> validator) : IRequestHandler<CreatePotionCommand, Guid>
{
    public async Task<Guid> Handle(CreatePotionCommand request, CancellationToken ct)
    {
        await validator.ValidateAndThrowAsync(request, ct);
        
        var isUnique = await checker.IsUniqueAsync<Potion>("Name", request.Name, ct);
        if (!isUnique)
        {
            ConflictException.Throw($"Зелье с названием {request.Name} уже существует");
        }
        
        var potion = Potion.Create(request.Name, request.Description);

        foreach (var effectId in request.EffectIds)
        {
            var effect = await effectRepository.GetByIdAsync(effectId, ct);
            if (effect == null)
            {
                throw new NotFoundException($"Эффект с ID {effectId} не найден");
            }
            potion.AddEffect(effect);
        }

        await potionRepository.AddAsync(potion, ct);
        return potion.Id.Value;
    }
}