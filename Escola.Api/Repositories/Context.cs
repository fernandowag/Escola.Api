using Escola.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Escola.Api.Repositories
{
    public class Context : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Turma> Turmas { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Aluno>(entity => entity.HasKey(e => new { e.Id }));
            modelBuilder.Entity<Aluno>()
                .HasOne(a => a.Turma)
                .WithMany(t => t.Alunos)
                .HasForeignKey(a => a.TurmaId);

            modelBuilder.Entity<Turma>(entity => entity.HasKey(e => new { e.Id }));
            modelBuilder.Entity<Turma>()
                .HasMany(t => t.Alunos);

        }
    }
}
