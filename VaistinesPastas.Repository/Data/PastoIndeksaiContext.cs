using Microsoft.EntityFrameworkCore;
using VaistinesPastas.Repository.Models;

namespace VaistinesPastas.Repository.Data
{
    public class PastoIndeksaiContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<QueryLog> QueryLog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=VaistinesPastas2;Trusted_Connection=True;")
                .AddInterceptors(new LogSQLQueriesInterceptor());
        }
    }
}
