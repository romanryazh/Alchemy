using FluentValidation;

namespace Alchemy.Application.Effects.Commands.CreateEffect;

public class CreateEffectCommandValidator : AbstractValidator<CreateEffectCommand>
{
    public CreateEffectCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Требуется указать Name")
            .MaximumLength(50).WithMessage("Name должно быть менее 100 символов");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Требуется указать Description")
            .MaximumLength(100).WithMessage("Description должен быть менее 100 символов");
    }
}