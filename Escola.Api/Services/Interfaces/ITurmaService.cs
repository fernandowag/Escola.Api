using Escola.Api.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escola.Api.Services.Interfaces
{
    public interface ITurmaService
    {
        Task<IEnumerable<TurmaResponse>> GetAll();
        Task<TurmaResponse> GetById(int id);
        Task<IEnumerable<TurmaResponse>> GetByDescription(string descricao);
        Task PostAsync(TurmaRequest turma);
    }
}
