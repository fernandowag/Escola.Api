﻿using System;

namespace Escola.Api.DataTransferObjects
{
    public class AlunoRequest
    {
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public int TurmaId { get; set; }
    }
}
