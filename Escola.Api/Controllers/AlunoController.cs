using Escola.Api.CrossCutting.Exceptions;
using Escola.Api.DataTransferObjects;
using Escola.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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

        /// <summary>
        /// Retorna uma lista com todos os Alunos.
        /// </summary>
        /// <remarks>
        /// Descrição:
        ///
        ///     GET /api/{version}/alunos
        ///     Retorna uma lista com todos os Alunos.
        ///
        /// </remarks>
        /// <returns>Um novo item criado</returns>
        /// <response code="200">Retorna uma lista com todos os alunos.</response>
        [HttpGet]
        [ProducesResponseType(typeof(AlunoResponse), 200)]
        public async Task<IActionResult> GetAll()
        {
            return this.Ok(await _alunoServices.GetAll());
        }

        /// <summary>
        /// Retorna um aluno correspondente ao id passado como parâmetro.
        /// </summary>
        /// <remarks>
        /// Descrição:
        /// 
        ///     GET /api/alunos/{id}
        ///     Retorna um aluno correspondente ao id passado como parâmetro
        /// 
        /// Id Exemplo:
        ///
        ///     1
        ///
        /// </remarks>
        /// <response code="200">Retorna o aluno correspondente ao id pesquisado</response>
        /// <response code="400">Se o valor pesquisado não for válido</response> 
        /// <response code="404">Se o valor pesquisado não for encontrado</response> 
        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(AlunoResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return this.Ok(await _alunoServices.GetById(id));
            }
            catch (Exception e)
            {
                return ExceptionHandler.GetErrorResponse(e);
            }
        }

        /// <summary>
        /// Retorna todos os alunos cujo nome contenha a string passada como parâmetro.
        /// </summary>
        /// <remarks>
        /// Descrição:
        /// 
        ///     GET api/alunos/filtros?nome=Francisco
        ///     Retorna todos os alunos cujo nome contenha a string passada como parâmetro.
        /// 
        /// Nome Exemplo:
        ///
        ///     Francisco
        ///
        /// </remarks>
        /// <response code="200">Retorna uma lista de alunos</response>
        /// <response code="400">Se o valor pesquisado não for válido</response> 
        /// <response code="404">Se o valor pesquisado não for encontrado</response> 
        [Route("filtros")]
        [HttpGet]
        [ProducesResponseType(typeof(AlunoResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        public async Task<IActionResult> Get([FromQuery]string nome)
        {
            return this.Ok( await _alunoServices.GetByName(nome));
        }

        /// <summary>
        /// Cria um novo aluno.
        /// </summary>
        /// <remarks>
        /// Descrição:
        /// 
        ///     Cria um novo aluno.
        ///     POST /api/{version}/alunos
        ///     
        /// Exemplo:
        /// 
        ///     {
        ///        "nome": "Maria Silva",
        ///        "dataDeNascimento: "2000-10-01",
        ///        "turma": 1
        ///     }
        ///
        /// </remarks>
        /// <returns>Um novo item criado</returns>
        /// <response code="201">Se o novo item for criado</response>
        /// <response code="400">Se o item não for criado</response> 
        [ProducesResponseType(typeof(ActionResult), 201)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [HttpPost]
        public async Task<IActionResult> PostAsync(AlunoRequest aluno)
        {
            await _alunoServices.PostAsync(aluno);
            return this.Created("alunos", aluno);
        }


        /// <summary>
        /// Atualiza a nota Geral de um aluno.
        /// </summary>
        /// <remarks>
        /// Descrição:
        /// 
        ///     Atualiza a nota Geral de um aluno.
        ///     PATCH /api/{version}/alunos/{id}?notaGerl={notaGeral}
        ///     
        /// id
        /// 
        ///     1
        ///     
        /// notaGeral
        /// 
        ///     10
        ///
        /// </remarks>
        /// <response code="204">Atualização realizada</response>
        /// <response code="400">Valores informados não são válidos</response> 
        /// <response code="404">Aluno não existe</response> 
        [Route("{id}")]
        [HttpPatch]
        [ProducesResponseType(typeof(AlunoResponse), 204)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        public async Task<IActionResult> UpdateNotaGeral(int id,[FromQuery] float notaGeral)
        {
            try
            {
                await _alunoServices.UpdateNotaGeral(id, notaGeral);
                return this.NoContent();
            }
            catch (Exception e)
            {
                return ExceptionHandler.GetErrorResponse(e);
            }
        }

        /// <summary>
        /// Atualiza os dados de um aluno.
        /// </summary>
        /// <remarks>
        /// Descrição:
        /// 
        ///     Atualiza os dados de um aluno.
        ///     PUT /api/{version}/alunos/{id}
        ///     
        /// id
        /// 
        ///     1
        ///     
        /// Exemplo:
        /// 
        ///     {
        ///        "nome": "Maria Silva",
        ///        "dataDeNascimento: "2000-10-01",
        ///        "turma": 1
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Atualização realizada</response>
        /// <response code="400">Valores informados não são válidos</response> 
        /// <response code="404">Aluno não existe</response> 
        [Route("{id}")]
        [HttpPut]
        [ProducesResponseType(typeof(AlunoResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        public async Task<IActionResult> Update(int id, [FromBody]AlunoRequest aluno)
        {
            try
            {
                await _alunoServices.Update(id, aluno);
                return this.NoContent();
            }
            catch (Exception e)
            {
                return ExceptionHandler.GetErrorResponse(e);
            }
        }

        /// <summary>
        /// Deleta um aluno.
        /// </summary>
        /// <remarks>
        /// Descrição:
        /// 
        ///     Deleta um aluno.
        ///     DELETE /api/{version}/alunos/{id}
        ///     
        /// id
        /// 
        ///     1
        ///     
        /// </remarks>
        /// <response code="204">Remoção realizada</response>
        /// <response code="400">Valores informados não são válidos</response> 
        /// <response code="404">Aluno não existe</response> 
        [Route("{id}")]
        [HttpDelete]
        [ProducesResponseType(typeof(AlunoResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _alunoServices.Delete(id);
                return this.NoContent();
            }
            catch (Exception e)
            {
                return ExceptionHandler.GetErrorResponse(e);
            }
        }

    }
}
