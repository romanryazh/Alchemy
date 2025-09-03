using MediatR;

namespace Alchemy.Application.Components.Commands.CreateComponent;

public record CreateComponentCommand : IRequest<Guid>
{
    /// <summary>
    /// Название
    /// </summary>
    /// <example>Рвотный Лист</example>
    public string Name { get; init; }

    /// <summary>
    /// Описание 
    /// </summary>
    /// <example>Цвет зелёной блевоты</example>
    public string Description { get; init; }

    /// <summary>
    /// Стоимость
    /// </summary>
    /// <example>100</example>
    public decimal Price { get; init; }

    public List<Guid> EffectIds { get; init; }

    public List<Guid> LocationIds { get; init; }

    public CreateComponentCommand(string name, string description, decimal price, List<Guid> effectIds,
        List<Guid> locationIds)
    {
        Name = name;
        Description = description;
        Price = price;
        EffectIds = effectIds;
        LocationIds = locationIds;
    }
}