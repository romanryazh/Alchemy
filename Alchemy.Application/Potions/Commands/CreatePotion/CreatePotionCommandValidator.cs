using Alchemy.Domain.Entities;
using FluentValidation;

namespace Alchemy.Application.Potions.Commands.CreatePotion;

public class CreatePotionCommandValidator : AbstractValidator<CreatePotionCommand>
{
    public CreatePotionCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Требуется указать Name")
            .MaximumLength(50).WithMessage("Name должно быть менее 50 символов");
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Требуется указать Description")
            .MaximumLength(100).WithMessage("Description должен быть менее 100 символов");
    }
}