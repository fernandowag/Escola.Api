using AutoMapper;
using Escola.Api.DataTransferObjects;
using Escola.Api.Models;
using Escola.Api.Repositories.Interfaces;
using Escola.Api.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escola.Api.Services
{

    public class TurmaService : ITurmaService
    {
        ITurmaRepository _turmaRepository;
        IMapper _mapper;

        public TurmaService(ITurmaRepository turmaRepository, IMapper mapper)
        {
            _turmaRepository = turmaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TurmaResponse>> GetAll()
        {
            var turmas = await _turmaRepository.GetAll();
            return _mapper.Map<IEnumerable<TurmaResponse>>(turmas);
        }

        public async Task<TurmaResponse> GetById(int id)
        {
            var turma = await _turmaRepository.Get(id);
            return _mapper.Map<TurmaResponse>(turma);
        }

        public async Task<IEnumerable<TurmaResponse>> GetByDescription(string descricao)
        {
            var turmas = await _turmaRepository.GetByDescription(descricao);
            return _mapper.Map<IEnumerable<TurmaResponse>>(turmas);
        }

        public async Task PostAsync(TurmaRequest turma)
        {
            await _turmaRepository.PostAsync(_mapper.Map<Turma>(turma));
        }
    }
}
