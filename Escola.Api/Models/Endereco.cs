using System.Collections.Generic;

namespace Escola.Api.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public int Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public virtual ICollection<Aluno> Alunos { get; set; }
    }
}
