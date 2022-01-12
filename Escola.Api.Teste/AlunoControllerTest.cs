using Escola.Api.Controllers;
using Escola.Api.CrossCutting.Exceptions;
using Escola.Api.Models;
using Escola.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Escola.Api.Teste
{
    public  class AlunoControllerTest
    {
        private MockRepository _mockRepository;
        Mock<IAlunoServices> _mockAlunoService;

        public AlunoControllerTest()
        {
            this._mockRepository = new MockRepository(MockBehavior.Default);
            this._mockAlunoService = this._mockRepository.Create<IAlunoServices>();
        }

        private AlunoController AlunoController()
        {
            return new AlunoController(this._mockAlunoService.Object);
        }

        [Theory]
        [InlineData(1)]
        public void GivenGetbyId_WhenTheIdIsValid_ThenShouldReturnAnOkObjectResult(int id)
        {
            //Arranje
            var alunoController = this.AlunoController();

            var aluno = Task.FromResult(new Aluno() { Id = id, Nome = "Francisco" });
            
            _mockAlunoService.Setup(x => x.GetById(id)).Returns(aluno).Verifiable();
            //Act

            var response = alunoController.GetById(id).Result;

            //Assert
            Assert.IsType<OkObjectResult>(response);
        }


        [Theory]
        [InlineData(1)]
        public void GivenGetbyId_WhenTheIdDoesNotExist_ThenShouldReturnAnNotFoundObjectResult(int id)
        {
            //Arranje
            var alunoController = this.AlunoController();
             
            //Act
            _mockAlunoService.Setup(x => x.GetById(id)).Throws(new NotFoundException(UserFrendlyCodes.NotFound, "ID", id)).Verifiable();

            var response = alunoController.GetById(id).Result;

            //Assert
            Assert.IsType<NotFoundObjectResult>(response);
        }

    }
}
