using Escola.Api.DataTransferObjects;
using Escola.Api.Models;
using Escola.Api.Repositories.Interfaces;
using Escola.Api.Services.Interfaces;
using System;
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

        public void Post(AlunoRequest alunoRequest)
        {

            if (alunoRequest.NomeDoAluno == null)
                throw new Exception("O nome do aluno não pode ser vazio");

            Aluno aluno = new Aluno() { Nome = alunoRequest.NomeDoAluno };
            _alunoRepository.Post(aluno);
        }
    }
}
