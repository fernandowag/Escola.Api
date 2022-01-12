using Escola.Api.DataTransferObjects;
using FluentValidation;
using System;

namespace Escola.Api.Validators
{
    public class AlunoResquestValidator : AbstractValidator<AlunoRequest>
    {
        public AlunoResquestValidator()
        {
            RuleFor(x => x.Nome).NotEmpty()
                .WithMessage("O nome do aluno não pode ser vazio");
            RuleFor(x => x.DataDeNascimento).NotEmpty().GreaterThan(DateTime.Now.AddYears(-100))
                .WithMessage("Data de nascimento invalida");
            RuleFor(x => x.TurmaId).NotEmpty().GreaterThan(0);
        }

    }
}
