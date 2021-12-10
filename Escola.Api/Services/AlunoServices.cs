using Escola.Api.Models;
using Escola.Api.Repositories.Interfaces;
using Escola.Api.Services.Interfaces;
using System.Collections.Generic;

namespace Escola.Api.Services
{
    
    public class AlunoServices : IAlunoServices
    {
        IAlunoRepository _alunoRepository;

        public AlunoServices(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public List<Aluno> GetAll()
        {
             return _alunoRepository.GetAll();
        }

        public Aluno Get(int id)
        {
            return _alunoRepository.Get(id);
        }

        public List<Aluno> Get(string nome)
        {
            return _alunoRepository.Get(nome);
        }


    }
}
