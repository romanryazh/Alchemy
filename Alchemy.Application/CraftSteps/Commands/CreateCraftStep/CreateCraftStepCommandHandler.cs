using Alchemy.Application.Common.Exceptions;
using Alchemy.Domain.Entities;
using Alchemy.Domain.Interfaces;
using MediatR;

namespace Alchemy.Application.CraftSteps.Commands.CreateCraftStep;

public class CreateCraftStepCommandHandler(IUnitOfWork unitOfWork, IUniqueCheckerService checker)
    : IRequestHandler<CreateCraftStepCommand, Guid>
{
    public async Task<Guid> Handle(CreateCraftStepCommand request, CancellationToken ct)
    {
        var isUnique = await checker.IsUniqueAsync<CraftStep>("Name", request.Name, ct);
        if (!isUnique)
        {
            ConflictException.Throw($"Шаг создания с названием {request.Name} уже существует");
        }
        
        var step = CraftStep.Create(request.Name, request.Description, request.Order);
        
        foreach (var componentId in request.ComponentIds)
        {
            var component = await unitOfWork.ComponentRepository.GetByIdAsync(componentId, ct);
            
            if (component == null)
            {
                throw new NotFoundException($"Компонент с ID {componentId} не найден");
            }
            
            step.AddComponent(component);
        }

        await unitOfWork.CraftStepRepository.AddAsync(step, ct);
        await unitOfWork.SaveChangesAsync(ct);
        
        return step.Id.Value;
    }
}