using Alchemy.Application.Potions.DTOs;
using MediatR;

namespace Alchemy.Application.Potions.Queries.GetPotion;

public record GetPotionByIdQuery(Guid Id) : IRequest<PotionDto>;