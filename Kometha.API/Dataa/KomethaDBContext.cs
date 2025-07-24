using Kometha.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Kometha.API.Dataa
{
    public class KomethaDBContext : DbContext
    {
        public KomethaDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
    }
}
