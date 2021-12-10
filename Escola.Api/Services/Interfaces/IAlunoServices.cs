using Escola.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.Api.Services.Interfaces
{
    public interface IAlunoServices
    {
        List<Aluno> GetAll();
        Aluno Get(int id);
        List<Aluno> Get(string nome);
    }
}
