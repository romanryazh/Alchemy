using Alchemy.Application.Common.Exceptions;
using Alchemy.Domain.Entities;
using Alchemy.Domain.Interfaces;
using MediatR;

namespace Alchemy.Application.Components.Commands.CreateComponent;

public class CreateComponentCommandHandler(IUnitOfWork unitOfWork, IUniqueCheckerService checker)
    : IRequestHandler<CreateComponentCommand, Guid>
{
    public async Task<Guid> Handle(CreateComponentCommand request, CancellationToken ct)
    {
        var uniqueAsync = await checker.IsUniqueAsync<Component>("Name", request.Name, ct);
        
        if (!uniqueAsync)
            ConflictException.Throw($"Компонент с названием {request.Name} уже существует");
        
        var component = Component.Create(request.Name, request.Description, request.Price);

        foreach (var effectId in request.EffectIds)
        {
            var effect = await unitOfWork.EffectRepository.GetByIdAsync(effectId, ct);
            
            if (effect == null)
                throw new NotFoundException($"Эффект с ID {effectId} не найден");
            
            component.AddEffect(effect);
        }

        foreach (var locationId in request.LocationIds)
        {
            var location = await unitOfWork.LocationRepository.GetByIdAsync(locationId, ct);
            
            if (location == null)
                throw new NotFoundException($"Локация с ID {locationId} не найден");
            
            component.AddLocation(location);
        }

        await unitOfWork.ComponentRepository.AddAsync(component, ct);
        await unitOfWork.SaveChangesAsync(ct);
        
        return component.Id.Value;
    }
}