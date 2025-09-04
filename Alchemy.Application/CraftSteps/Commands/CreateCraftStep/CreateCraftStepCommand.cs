using MediatR;

namespace Alchemy.Application.CraftSteps.Commands.CreateCraftStep;

public record CreateCraftStepCommand : IRequest<Guid>
{
    /// <summary>
    /// Название шага создания
    /// </summary>
    /// <example></example>
    public string Name { get; init; }
    
    /// <summary>
    /// Описание шага
    /// </summary>
    /// <example></example>
    public string Description { get; init; }
    
    /// <summary>
    /// Порядковый номер шага 
    /// </summary>
    /// <example>(например: 1)</example>
    public int Order { get; init; }
    
    /// <summary>
    /// Коллекция Id компонентов 
    /// </summary>
    public List<Guid> ComponentIds { get; init; }

    public CreateCraftStepCommand(string name, string description, int order, List<Guid> componentIds)
    {
        Name = name;
        Description = description;
        Order = order;
        ComponentIds = componentIds;
    }
}