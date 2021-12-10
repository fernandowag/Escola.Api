using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escola.Api.Models;
using Escola.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Escola.Api.Controllers
{
    [ApiController]
    [Route("api/alunos")]
    public class AlunoController : ControllerBase
    {
        IAlunoServices _alunoServices;
        public AlunoController(IAlunoServices alunoServices)
        {
            _alunoServices = alunoServices;
        }

        // Retorna todos os registros da tabela Alunos
        // GET api/alunos
        [HttpGet]
        public List<Aluno> GetAll()
        {
            return _alunoServices.GetAll();
        }

        // Retorna um único registro cujo id corresponda ao passado como parâmetro
        // GET api/alunos/1
        [Route("{id}")]
        [HttpGet]
        public Aluno Get(int id)
        {
            return _alunoServices.Get(id);
        }

        // Retorna todos os alunos cujo nome contenha a string passada como parâmetro
        // GET api/alunos/filtro?nome=Francisco
        [Route("filtro")]
        [HttpGet]
        public List<Aluno> Get(string nome)
        {
            return _alunoServices.Get(nome);
        }
    }
}
