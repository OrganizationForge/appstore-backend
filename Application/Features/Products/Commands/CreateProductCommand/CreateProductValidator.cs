using FluentValidation;

namespace Application.Features.Products.Commands.CreateProductCommand
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {

        public CreateProductValidator()
        {
            RuleFor(p => p.ProductName)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.");

            RuleFor(p => p.PriceBase)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.");

            RuleFor(p => p.BrandId)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.");

            RuleFor(p => p.CategoryId)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.");

        }
    }
}
