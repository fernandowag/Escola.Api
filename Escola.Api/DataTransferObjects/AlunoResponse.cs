using System;

namespace Escola.Api.DataTransferObjects
{
    public class AlunoResponse
    {
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public float NotaGeral { get; set; }
        public bool Aprovado { get; set; }

    }
}
