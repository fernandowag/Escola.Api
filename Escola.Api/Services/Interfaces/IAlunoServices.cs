using Escola.Api.DataTransferObjects;
using Escola.Api.Models;
using System.Collections.Generic;

namespace Escola.Api.Services.Interfaces
{
    public interface IAlunoServices
    {
        List<Aluno> GetAll();
        Aluno Get(int id);
        List<Aluno> Get(string nome);
        void Post(AlunoRequest aluno);
    }
}
