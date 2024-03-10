using System.Text.RegularExpressions;
using FluentValidation;
using LojaVirtual.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace LojaVirtual.Domain.Validators;

public sealed class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user.UserName)
        .NotEmpty().WithMessage("O nome de usuário é obrigatório.")
        .NotNull().WithMessage("O nome de usuário é obrigatório.");

        RuleFor(user => user.Email)
        .Matches(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*").WithMessage("O E-mail é obrigatório")
        .EmailAddress().WithMessage("O email fornecido não é válido.");

        RuleFor(user => user.PasswordHash)
        .NotEmpty().WithMessage("A senha é obrigatória.");

        RuleFor(user => user.PasswordHash)
        .Matches(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$").WithMessage("A Senha deve ter no mínimo 8 caracteres, uma letra, um caracter especial e um número.");

    }
}