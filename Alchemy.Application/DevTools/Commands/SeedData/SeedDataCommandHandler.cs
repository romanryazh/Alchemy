using Alchemy.Domain.Entities;
using Alchemy.Domain.Interfaces;
using MediatR;

namespace Alchemy.Application.DevTools.Commands.SeedData;

public class SeedDataCommandHandler(IEffectRepository effectRepository, IPotionRepository potionRepository)
    : IRequestHandler<SeedDataCommand, SeedDataResultDto>
{
    public async Task<SeedDataResultDto> Handle(SeedDataCommand request, CancellationToken ct)
    {
        var healEffect = Effect.Create("Лечение", "Лечит");
        await effectRepository.AddAsync(healEffect, ct);

        var toxicEffect = Effect.Create("Отравление", "Вызывает кишечное недомогание");
        await effectRepository.AddAsync(toxicEffect, ct);

        var healingPotion = Potion.Create("Настойка боярышника", "Исцеляет недомогания, восстанавливает конечности");
        healingPotion.AddEffect(healEffect);
        await potionRepository.AddAsync(healingPotion, ct);

        var poisonPotion = Potion.Create("Яд", "Убивает насмерть");
        poisonPotion.AddEffect(toxicEffect);
        await potionRepository.AddAsync(poisonPotion, ct);

        return new SeedDataResultDto("Данные успешно инициализированы");
    }
}