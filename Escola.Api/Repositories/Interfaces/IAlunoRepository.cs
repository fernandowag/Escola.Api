using Escola.Api.DataTransferObjects;
using Escola.Api.Models;
using System.Collections.Generic;

namespace Escola.Api.Repositories.Interfaces
{
    public interface IAlunoRepository
    {
        List<Aluno> GetAll();
        Aluno Get(int id);
        List<Aluno> Get(string nome);
        void Post(Aluno aluno);
    }
}
