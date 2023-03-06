using Microsoft.EntityFrameworkCore;
using ProjetoCadastroDeClientes.Data.Map;
using ProjetoCadastroDeClientes.Models;

namespace ProjetoCadastroDeClientes.Data
{
    public class CadastroClientesDBContext : DbContext
    {
        public CadastroClientesDBContext(DbContextOptions<CadastroClientesDBContext> options) : base(options)
        {
        }

        public DbSet<ClienteModel> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
