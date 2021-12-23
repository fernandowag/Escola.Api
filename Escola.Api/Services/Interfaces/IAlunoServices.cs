using Escola.Api.DataTransferObjects;
using Escola.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escola.Api.Services.Interfaces
{
    public interface IAlunoServices
    {
        List<Aluno> GetAll();
        Task<Aluno> GetById(int id);
        List<Aluno> Get(string nome);
        void Post(AlunoRequest aluno);
    }
}
