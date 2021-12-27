using Escola.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Escola.Api.Repositories
{
    public class Context : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }

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
            modelBuilder.Entity<Aluno>(entity => entity.HasKey( e => new { e.Id }));

            modelBuilder.Entity<Aluno>();
 //  .HasMany(b => b.Enderecos)
 //  .WithMany(c => c.Alunos)
 //  .LeftNavigation.
 //  L
 //
 //      cs.MapRightKey("CategoryId");
 //      cs.ToTable("BookCategories");
 //  });
        }
    }
}
