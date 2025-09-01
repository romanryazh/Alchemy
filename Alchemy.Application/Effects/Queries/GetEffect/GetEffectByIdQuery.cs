using Alchemy.Application.Effects.DTOs;
using MediatR;

namespace Alchemy.Application.Effects.Queries.GetEffect;

public record GetEffectByIdQuery(Guid Id) : IRequest<EffectDto>;