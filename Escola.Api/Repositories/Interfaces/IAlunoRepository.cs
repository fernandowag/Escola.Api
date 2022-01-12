using Escola.Api.DataTransferObjects;
using Escola.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escola.Api.Repositories.Interfaces
{
    public interface IAlunoRepository
    {
        Task<IEnumerable<Aluno>> GetAll();
        Task<Aluno> Get(int id);
        Task<IEnumerable<Aluno>> GetByName(string nome);
        Task PostAsync(Aluno aluno);
        Task UpdateNotaGeral(int id, float notaGeral);
        Task Update(int id, AlunoRequest aluno);
        Task Delete(int id);
    }
}
