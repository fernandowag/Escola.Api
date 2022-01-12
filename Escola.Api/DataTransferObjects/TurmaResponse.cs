
using Escola.Api.Models;
using System.Collections.Generic;

namespace Escola.Api.DataTransferObjects
{
    public class TurmaResponse
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Turno { get; set; }
        public IEnumerable<AlunoResponse> Alunos { get; set; }
    }
}
