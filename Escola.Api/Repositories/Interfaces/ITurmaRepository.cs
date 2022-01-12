using Escola.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escola.Api.Repositories.Interfaces
{
    public interface ITurmaRepository
    {
        Task<IEnumerable<Turma>> GetAll();
        Task<Turma> Get(int id);
        Task<IEnumerable<Turma>> GetByDescription(string descricao);
        Task PostAsync(Turma turma);
    }
}
