using Escola.Api.DataTransferObjects;
using Escola.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escola.Api.Repositories.Interfaces
{
    public interface IAlunoRepository
    {
        List<Aluno> GetAll();
        Task<Aluno> Get(int id);
        List<Aluno> Get(string nome);
        void Post(Aluno aluno);
    }
}
