﻿using System.Collections.Generic;

namespace Escola.Api.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
