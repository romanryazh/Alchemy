using System.ComponentModel.DataAnnotations;
using Alchemy.Domain.ValueObjects;
using MediatR;

namespace Alchemy.Application.Potions.Commands.CreatePotion;

public record CreatePotionCommand : IRequest<Guid>
{
    /// <summary>
    /// Название зелья
    /// </summary>
    /// <example>Настойка боярышника</example>
    public string Name { get; init; }
    
    /// <summary>
    /// Описание зелья
    /// </summary>
    /// <example>Продаётся в ваших аптеках</example>
    public string Description { get; init; }
    
    /// <summary>
    /// Коллекция Id эффектов зелья
    /// </summary>
    public List<Guid> EffectIds { get; init; }

    public CreatePotionCommand(string name, string description, List<Guid> effectIds)
    {
        Name = name;
        Description = description;
        EffectIds = effectIds;
    }
}