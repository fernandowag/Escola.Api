using Escola.Api.CrossCutting.Exceptions;
using Escola.Api.Models;
using Escola.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.Api.Repositories
{
    public class TurmaRepository : ITurmaRepository
    {
        private readonly Context _context;

        public TurmaRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Turma>> GetAll()
        {
            var result = _context.Turmas.AsEnumerable();
            return await Task.FromResult(result);
        }

        public Task<Turma> Get(int id)
        {
            var result = _context.Turmas.Include(x => x.Alunos).Where(a => a.Id == id).FirstOrDefault();
            if (result == null)
                throw new NotFoundException(UserFrendlyCodes.NotFound, "ID", id);
            return Task.FromResult(result);
        }

        public async Task<IEnumerable<Turma>> GetByDescription(string descricao)
        {
            var result = _context.Turmas.Where(a => a.Descricao.Contains(descricao)).ToList();
            return await Task.FromResult(result);
        }

        public async Task PostAsync(Turma turma)
        {
            await _context.Turmas.AddAsync(turma);
            await _context.SaveChangesAsync(); 
        }
    }
}
