using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Escola.Api.CrossCutting;
using Escola.Api.CrossCutting.Exceptions;
using Escola.Api.DataTransferObjects;
using Escola.Api.Models;
using Escola.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Escola.Api.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/alunos")]
    [ApiController]
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
        [ProducesResponseType(typeof(ErrorResponse), 200)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _alunoServices.GetById(id);
                return this.Ok(result); 
            }
            catch(Exception e)
            {
                return ExceptionHandler.GetErrorResponse(e);
            }
        }

        // Retorna todos os alunos cujo nome contenha a string passada como parâmetro
        // GET api/alunos/filtro?nome=Francisco
        [Route("filtro")]
        [HttpGet]
        public List<Aluno> Get([FromQuery]string nome)
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
