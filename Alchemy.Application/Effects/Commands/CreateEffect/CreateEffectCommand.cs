using System.ComponentModel.DataAnnotations;
using Alchemy.Application.Effects.DTOs;
using MediatR;

namespace Alchemy.Application.Effects.Commands.CreateEffect;

public record CreateEffectCommand : IRequest<Guid>
{
    /// <summary>
    /// Название эффекта
    /// </summary>
    /// <example>Лечение</example>
    [Required(AllowEmptyStrings = false, ErrorMessage = "Название обязательно")]
    [StringLength(50, ErrorMessage = "Название не должно превышать 50 символов")]
    public string Name { get; init; }
    
    /// <summary>
    /// Описание эффекта
    /// </summary>
    /// <example>Лечит</example>
    [Required(AllowEmptyStrings = false, ErrorMessage = "Описание обязательно")]
    [StringLength(100, ErrorMessage = "Описание не должно превышать 100 символов")]
    public string Description { get; init; }
}