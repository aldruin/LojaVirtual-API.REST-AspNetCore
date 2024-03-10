using FluentValidation;
using LojaVirtual.Domain.Entities;

namespace LojaVirtual.Domain.Validators;
public sealed class CartValidator : AbstractValidator<Cart>
{
    public CartValidator()
    {
        RuleFor(cart => cart.UserId)
            .NotEmpty().WithMessage("O ID do usuário é obrigatório.");

        RuleFor(cart => cart.Products)
            .Must(products => products == null || products.All(cartProduct => cartProduct.Quantity > 0))
            .WithMessage("A quantidade de cada produto no carrinho deve ser maior que zero.");
    }
}