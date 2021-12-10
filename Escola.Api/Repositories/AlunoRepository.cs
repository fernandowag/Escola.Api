using Escola.Api.Models;
using Escola.Api.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

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

        public Aluno Get(int id)
        {
            return _context.Alunos.Where(a => a.Id == id).FirstOrDefault();
        }

        public List<Aluno> Get(string nome)
        {
            return _context.Alunos.Where(a => a.Nome.Contains(nome)).ToList();
        }

    }
}
