using Business.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data.Context
{
    public partial class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<HistoricoEscolar> HistoricosEscolares { get; set; }
        public DbSet<Escolaridade> Escolaridades { get; set; }
    }
}
