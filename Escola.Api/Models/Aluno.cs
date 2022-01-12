using System;
using System.Collections.Generic;

namespace Escola.Api.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public int TurmaId { get; set; }
        public virtual Turma Turma { get; set; }
        public bool Ativo { get; set; }
        public float NotaGeral { get; set; } 
    }
}
