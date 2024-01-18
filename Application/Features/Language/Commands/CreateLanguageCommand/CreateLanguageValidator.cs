using FluentValidation;

namespace Application.Features.Language.Commands.CreateLanguageCommand
{
    public class CreateLanguageValidator : AbstractValidator<CreateIdiomCommand>
    {
        public CreateLanguageValidator()
        {
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(2).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres.");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.");
        }
    }
}
