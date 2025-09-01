using MediatR;

namespace Alchemy.Application.Effects.Commands.UpdateEffect;

public record UpdateEffectCommand(Guid Id, string Name, string Description) : IRequest;