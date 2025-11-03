using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Kometha.API.Dataa
{
    public class DesignTimeKomethaDbContextFactory : IDesignTimeDbContextFactory<KomethaDBContext>
    {
        public KomethaDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<KomethaDBContext>();

            // MISMA CADENA DE appsettings.json
            var connectionString = "Server=KOMETHA-PC;Database=KomethaDb;Trusted_Connection=True;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);

            return new KomethaDBContext(optionsBuilder.Options);
        }
    }
}