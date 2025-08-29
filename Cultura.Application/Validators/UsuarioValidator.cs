using Cultura.Application.Dtos.Input;
using Cultura.Domain.Entities;
using FluentValidation;


namespace Cultura.Application.Validator;

public class UsuarioValidator : AbstractValidator<UsuarioInputDto>
{
    public UsuarioValidator()
    {
        RuleFor(x => x.Email)
    .Cascade(CascadeMode.Continue)
    .NotEmpty().WithMessage("O email é obrigatório.")
    .EmailAddress().WithMessage("O email informado não é válido.");

        RuleFor(x => x.Email)
    .Cascade(CascadeMode.Stop)
    .NotEmpty().WithMessage("O e-mail é obrigatório.")
    .EmailAddress().WithMessage("Formato de e-mail inválido.")
    .MaximumLength(100).WithMessage("O e-mail pode ter no máximo 100 caracteres.");

        RuleFor(x => x.Telefone)
    .Cascade(CascadeMode.Continue)
    .NotEmpty().WithMessage("O telefone é obrigatório.")
    .Matches(@"^\(\d{2}\) \d{4,5}-\d{4}$").WithMessage("O telefone deve estar no formato (XX) XXXX-XXXX ou (XX) XXXXX-XXXX.");

        RuleFor(x => x.Nome)
    .Cascade(CascadeMode.Stop)
    .NotEmpty().WithMessage("O nome é obrigatório.")
    .MinimumLength(3).WithMessage("O nome precisa ter no mínimo 3 caracteres.")
    .MaximumLength(50).WithMessage("O nome pode ter no máximo 50 caracteres.")
    .Matches("^[a-zA-ZÀ-ú\\s]+$").WithMessage("O nome deve conter apenas letras.");

        RuleFor(x => x.Email)
    .Cascade(CascadeMode.Stop)
    .NotEmpty().WithMessage("O e-mail é obrigatório.")
    .EmailAddress().WithMessage("Formato de e-mail inválido.")
    .MaximumLength(100).WithMessage("O e-mail pode ter no máximo 100 caracteres.");

        RuleFor(x => x.Senha)
    .Cascade(CascadeMode.Stop)
    .NotEmpty().WithMessage("A senha é obrigatória.")
    .MinimumLength(6).WithMessage("A senha precisa ter no mínimo 6 caracteres.")
    .Matches("[A-Z]").WithMessage("A senha deve conter pelo menos uma letra maiúscula.")
    .Matches("[a-z]").WithMessage("A senha deve conter pelo menos uma letra minúscula.")
    .Matches("[0-9]").WithMessage("A senha deve conter pelo menos um número.")
    .Matches("[^a-zA-Z0-9]").WithMessage("A senha deve conter pelo menos um caractere especial.");

        RuleFor(x => x.Telefone)
    .Cascade(CascadeMode.Stop)
    .NotEmpty().WithMessage("O telefone é obrigatório.")
    .Matches(@"^\(?\d{2}\)?[\s-]?(\d{4,5})[\s-]?(\d{4})$").WithMessage("Telefone inválido. Use o formato (XX) XXXXX-XXXX.");

        RuleFor(x => x.DataNascimento)
    .Cascade(CascadeMode.Stop)
    .NotEmpty().WithMessage("A data de nascimento é obrigatória.")
    .LessThan(DateTime.Today).WithMessage("A data de nascimento deve ser no passado.")
    .Must(data => data <= DateTime.Today.AddYears(-18)).WithMessage("O usuário deve ter no mínimo 18 anos.");
    }
}
