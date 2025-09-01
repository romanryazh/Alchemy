using Alchemy.Application.Common.Exceptions;
using Alchemy.Application.Effects.DTOs;
using Alchemy.Domain.Entities;
using Alchemy.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace Alchemy.Application.Effects.Commands.CreateEffect;

public class CreateEffectCommandHandler(
    IEffectRepository effectRepository,
    IValidator<CreateEffectCommand> validator,
    IUniqueCheckerService checker)
    : IRequestHandler<CreateEffectCommand, Guid>
{
    public async Task<Guid> Handle(CreateEffectCommand request, CancellationToken ct)
    {
        await validator.ValidateAndThrowAsync(request, ct);

        var isUnique = await checker.IsUniqueAsync<Effect>("Name", request.Name, ct);
        if (!isUnique)
        {
            ConflictException.Throw($"Эффект с названием {request.Name} уже существует");
        }

        var effect = Effect.Create(request.Name, request.Description);

        await effectRepository.AddAsync(effect, ct);
        return effect.Id.Value;
    }
}