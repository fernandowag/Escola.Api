using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escola.Api.Models
{
    [Table("Turmas")]
    public class Turma
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Turno { get; set; }
        public virtual IEnumerable<Aluno> Alunos { get; set; }
    }
}
