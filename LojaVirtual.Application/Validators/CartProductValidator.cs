using FluentValidation;
using LojaVirtual.Domain.Entities;

namespace LojaVirtual.Application.Validators;
public sealed class CartProductValidator : AbstractValidator<CartProduct>
{
    public CartProductValidator()
    {
        RuleFor(cp => cp.CartId)
            .NotEmpty().WithMessage("O ID do carrinho é obrigatório.");

        RuleFor(cp => cp.ProductId)
            .NotEmpty().WithMessage("O ID do produto é obrigatório.");

        RuleFor(cp => cp.Quantity)
            .GreaterThan(0).WithMessage("A quantidade do produto deve ser maior que zero.");
    }
}