using Escola.Api.DataTransferObjects;
using FluentValidation;
using System;
using System.Linq;

namespace Escola.Api.Validators
{
    public class TurmaRequestValidator : AbstractValidator<TurmaRequest>
    {
        public TurmaRequestValidator()
        {
            RuleFor(x => x.Descricao).NotEmpty()
                .WithMessage("O nome do aluno não pode ser vazio");
            RuleFor(x => x.Turno).NotEmpty()
                       .Must(TurnoValido).WithMessage("Turno deve ser 'Manhã' ou 'Tarde'");
        }

        public bool TurnoValido(string turno)
        {
            return new string[] { "manhã", "tarde" }.Contains(turno) ? true : false;

        }

    }
}
