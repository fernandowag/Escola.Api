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

        public async Task<IEnumerable<Aluno>> GetAll()
        {
            var result = _context.Alunos.AsEnumerable();
            return await Task.FromResult(result);
        }

        public Task<Aluno> Get(int id)
        {
            var result = _context.Alunos.Where(a => a.Id == id).FirstOrDefault();
            if (result == null)
                throw new NotFoundException(UserFrendlyCodes.NotFound, "ID", id);
            return Task.FromResult(result);
        }

        public async Task<IEnumerable<Aluno>> GetByName(string nome)
        {
            var result =  _context.Alunos.Where(a => a.Nome.Contains(nome)).ToList();
            return await Task.FromResult(result);
        }

        public async Task PostAsync(Aluno aluno)
        {
            await _context.Alunos.AddAsync(aluno);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateNotaGeral(int id, float notaGeral)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            aluno.NotaGeral = notaGeral;
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, AlunoRequest alunoRequest)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            aluno.Nome = alunoRequest.Nome;
            aluno.DataDeNascimento = alunoRequest.DataDeNascimento;
            aluno.TurmaId = alunoRequest.TurmaId;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            _context.Alunos.Remove(aluno);
            _context.SaveChanges();

        }
    }
}
