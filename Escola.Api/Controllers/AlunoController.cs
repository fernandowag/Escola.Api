using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escola.Api.CrossCutting;
using Escola.Api.DataTransferObjects;
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

        /// <summary>Retorna todos os registros da tabela Alunos</summary> 
        /// <remarks>
        ///     Descrção
        ///         GET api/alunos
        ///         Consulta a tabela alunos e retorna todos os registros.
        /// 
        /// </remarks>
        [HttpGet]
        public List<Aluno> GetAll()
        {
            return _alunoServices.GetAll();
        }

        /// <summary>Retorna um único registro cujo id corresponda ao passado como parâmetros</summary> 
        /// <remarks>
        /// Descrção
        ///     GET api/alunos/{id}
        ///     Retorna um único registro cujo id corresponda ao passado como parâmetro.
        ///     
        /// Exemplo
        ///     1
        /// </remarks>
        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(Aluno),200)]
        [ProducesResponseType(typeof(FrendlyException), 400)]
        public object GetById(string id)
        {
            try
            {
                int idConvertido = Int32.Parse(id);
                return _alunoServices.Get(idConvertido);
            }
            catch 
            {
                //  ReturnResponse response = new ReturnResponse(e);
                //  return response.Mensagem;
                //throw new Exception("Houve um erro");
                throw new FrendlyException("Houve um erro");
            }
        }

        // Retorna todos os alunos cujo nome contenha a string passada como parâmetro
        // GET api/alunos/filtro?nome=Francisco
        [Route("filtro")]
        [HttpGet]
        public List<Aluno> Get(string nome)
        {
            return _alunoServices.Get(nome);
        }

        [HttpPost]
        public IActionResult Post(AlunoRequest aluno)
        {
            _alunoServices.Post(aluno);
            return Created("alunos", aluno);
        }
    }
}
