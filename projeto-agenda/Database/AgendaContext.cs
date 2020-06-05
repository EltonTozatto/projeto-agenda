using Microsoft.EntityFrameworkCore;
using projeto_agenda.Entidades;

namespace projeto_agenda.Database
{
    class AgendaContext : DbContext
    {
        public DbSet<Contato> Contatos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Agenda; Integrated Security=true;");
        }
    }
}
