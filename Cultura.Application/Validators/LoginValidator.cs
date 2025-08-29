using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cultura.Application.Dtos.Input;
using FluentValidation;

namespace Cultura.Application.Validators;
public class LoginValidator : AbstractValidator<LoginInputDto>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email)
    .NotEmpty().WithMessage("O campo Email é obrigatório.")
    .EmailAddress().WithMessage("O campo Email deve ser um endereço de email válido.");

        RuleFor(x => x.Senha)
    .NotEmpty().WithMessage("O campo Senha é obrigatório.")
    .MinimumLength(6).WithMessage("A Senha deve ter pelo menos 6 caracteres.");
    }
}