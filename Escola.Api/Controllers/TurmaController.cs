using Escola.Api.DataTransferObjects;
using Escola.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Escola.Api.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/turmas")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        ITurmaService _turmaService;

        public TurmaController(ITurmaService turmaService)
        {
            _turmaService = turmaService;
        }

        /// <summary>
        /// Retorna uma turma, e seus alunos, correspondente ao id passado como parâmetro.
        /// </summary>
        /// <remarks>
        /// Descrição:
        /// 
        ///     GET /api/turmas/{id}
        ///     Retorna uma turma, e seus alunos, correspondente ao id passado como parâmetro
        /// 
        /// Id Exemplo:
        ///
        ///     1
        ///
        /// </remarks>
        /// <response code="200">Retorna a turma correspondente ao id pesquisado</response>
        /// <response code="400">Se o valor pesquisado não for válido</response> 
        /// <response code="404">Se o valor pesquisado não for encontrado</response> 
        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(AlunoResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        public async Task<IActionResult> GetById(int id)
        {
                return this.Ok(await _turmaService.GetById(id));
        }

        /// <summary>
        /// Cria uma nova turma.
        /// </summary>
        /// <remarks>
        /// Descrição:
        /// 
        ///     Cria uma nova turma.
        ///     POST /api/{version}/turmas
        ///     
        /// Exemplo:
        /// 
        ///     {
        ///        "descricao": "1° ano A",
        ///        "turno": "manhã"
        ///     }
        ///
        /// </remarks>
        /// <returns>Um novo item criado</returns>
        /// <response code="201">Se o novo item for criado</response>
        /// <response code="400">Se o item não for criado</response> 
        [ProducesResponseType(typeof(ActionResult), 201)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [HttpPost]
        public async Task<IActionResult> Post(TurmaRequest turma)
        {
            await _turmaService.PostAsync(turma);
            return  this.Created("turmas", turma);
        }
    }
}
