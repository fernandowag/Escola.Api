using Escola.Api.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escola.Api.Services.Interfaces
{
    public interface IAlunoServices
    {
        Task<IEnumerable<AlunoResponse>> GetAll();
        Task<AlunoResponse> GetById(int id);
        Task<IEnumerable<AlunoResponse>> GetByName(string nome);
        Task PostAsync(AlunoRequest aluno);
        Task UpdateNotaGeral(int id, float notaGeral);
        Task Update(int id, AlunoRequest aluno);
        Task Delete(int id);

    }
}
