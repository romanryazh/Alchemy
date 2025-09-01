using MediatR;

namespace Alchemy.Application.Effects.Commands.DeleteEffect;

public record DeleteEffectCommand(Guid Id) : IRequest;