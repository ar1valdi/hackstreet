using Microsoft.EntityFrameworkCore;

namespace HackstreeetServer.src.DatabaseContext
{
    public class GreenLifeDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString =
                "Host=hackathon.cajolvhflhhy.eu-north-1.rds.amazonaws.com;Username=postgres;Password=hackstreet_boys;Database=GreenLife;SearchPath=public;";
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GreenLifeDbContext).Assembly);
        }
    }
}
