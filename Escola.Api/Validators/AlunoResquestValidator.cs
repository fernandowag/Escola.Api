using Escola.Api.DataTransferObjects;
using FluentValidation;
using System.Linq;

namespace Escola.Api.Validators
{
    public class AlunoResquestValidator : AbstractValidator<AlunoRequest>
    {
        public AlunoResquestValidator()
        {
            RuleFor(x => x.NomeDoAluno).NotEmpty()
                .WithMessage("O nome do aluno não pode ser vazio");
            RuleFor(x => x.Idade).GreaterThan(10);
            RuleFor(x => x.Turno)
                .Must(TurnoValido).WithMessage("Turno deve ser 'Manhã' ou 'Tarde'");
        }

        public bool TurnoValido(string turno)
        {
            return new string[] { "manhã", "tarde" }.Contains(turno) ? true : false;

        }

    }
}
