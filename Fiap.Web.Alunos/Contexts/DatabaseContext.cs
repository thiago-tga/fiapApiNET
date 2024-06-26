using Fiap.Web.Alunos.Models;
using Fiap.Web.Alunos.Contexts;

//ERROOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO

namespace Fiap.Web.Alunos.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DbSet<AgendamentoModel> Agendamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgendamentoModel>(entity =>
            {
                entity.ToTable("Agendamentos");
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Endereco).IsRequired();
                entity.Property(a => a.Data).HasColumnType("DATE");
                entity.Property(a => a.Cliente).IsRequired();
                entity.Property(a => a.StatusColeta).IsRequired();
            });
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected DatabaseContext()
        {
        }
    }
}
