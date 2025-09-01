using Alchemy.Application.Effects.DTOs;
using Alchemy.Domain.Entities;

namespace Alchemy.Application.Potions.DTOs;

public record PotionDto(Guid Id, string Name, string Description, List<EffectDto> Effects);