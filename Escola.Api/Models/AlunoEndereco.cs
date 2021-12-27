using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escola.Api.Models
{
    public class AlunoEndereco
    {
        [Key, Column(Order = 1)]
        public int BookId { get; set; }
        [Key, Column(Order = 2)]
        public int CategoryId { get; set; }
        public Aluno Aluno { get; set; }
        public Endereco Endereco { get; set; }

    }
}
