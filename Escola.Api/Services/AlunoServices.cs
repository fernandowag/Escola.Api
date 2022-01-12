using AutoMapper;
using Escola.Api.DataTransferObjects;
using Escola.Api.Models;
using Escola.Api.Repositories.Interfaces;
using Escola.Api.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escola.Api.Services
{

    public class AlunoServices : IAlunoServices
    {
        IAlunoRepository _alunoRepository;
        IMapper _mapper;

        public AlunoServices(IAlunoRepository alunoRepository, IMapper mapper)
        {
            _alunoRepository = alunoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AlunoResponse>> GetAll()
        {
            var alunos = await _alunoRepository.GetAll();
            return _mapper.Map<IEnumerable<AlunoResponse>>(alunos);
        }

        public async Task<AlunoResponse> GetById(int id)
        {
            var aluno = await _alunoRepository.Get(id);
            return _mapper.Map<AlunoResponse>(aluno);
        }

        public async Task<IEnumerable<AlunoResponse>> GetByName(string nome)
        {
            var alunos = await _alunoRepository.GetByName(nome);
            return _mapper.Map<IEnumerable<AlunoResponse>>(alunos);
        }

        public async Task PostAsync(AlunoRequest aluno)
        {
            await _alunoRepository.PostAsync(_mapper.Map<Aluno>(aluno));
        }

        public async Task UpdateNotaGeral(int id, float notaGeral)
        {
            await _alunoRepository.UpdateNotaGeral(id, notaGeral);
        }

        public async Task Update(int id, AlunoRequest aluno)
        {
            await _alunoRepository.Update(id, aluno);
        }

        public async Task Delete(int id)
        {
            await _alunoRepository.Delete(id);
        }
    }
}
