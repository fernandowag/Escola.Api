using Escola.Api.CrossCutting.Exceptions;
using Escola.Api.DataTransferObjects;
using Escola.Api.Models;
using Escola.Api.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.Api.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        List<Aluno> alunos = new List<Aluno>();

        private readonly Context _context;

        public AlunoRepository(Context context)
        {
            _context = context;
        }
        public List<Aluno> GetAll()
        {
            return _context.Alunos.ToList();
        }

        public Task<Aluno> Get(int id)
        {
            var result = _context.Alunos.Where(a => a.Id == id).FirstOrDefault();
            if (result == null)
                throw new NotFoundException(UserFrendlyCodes.NotFound, "ID", id);
            return Task.FromResult(result);
        }

        public List<Aluno> Get(string nome)
        {
            return _context.Alunos.Where(a => a.Nome.Contains(nome)).ToList();
        }

        public void Post(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            _context.SaveChanges();
        }
    }
}
