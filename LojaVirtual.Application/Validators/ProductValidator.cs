using FluentValidation;
using LojaVirtual.Application.DataTransferObjects;

namespace LojaVirtual.Application.Validators;
public sealed class ProductValidator : AbstractValidator<ProductDto>
{
    public ProductValidator()
    {
        RuleFor(product => product.Name)
            .NotEmpty().WithMessage("O nome do produto é obrigatório.")
            .MaximumLength(100).WithMessage("O nome do produto não pode ter mais de 100 caracteres.");

        RuleFor(product => product.Price)
            .GreaterThan(0).WithMessage("O preço do produto deve ser maior que zero.");

        RuleFor(product => product.Stock)
            .GreaterThanOrEqualTo(0).WithMessage("O estoque do produto não pode ser negativo.");

        RuleFor(product => product.Description)
            .NotEmpty().WithMessage("A descrição do produto é obrigatória.")
            .MaximumLength(500).WithMessage("A descrição do produto não pode ter mais de 500 caracteres.");
    }
}