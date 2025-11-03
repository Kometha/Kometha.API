using Kometha.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Kometha.API.Dataa
{
    public class KomethaDBContext : DbContext
    {
        public KomethaDBContext(DbContextOptions<KomethaDBContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for difficulties
            // Easy, Medium, Hard

            var difficulties = new List<Difficulty>()
            {

                new Difficulty()
                {
                    Id = Guid.Parse("7674c000-85d1-469b-8460-5043b6fc5575"),
                    Name  = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("6a7f1c92-f224-4b23-a6db-28e556f054db"),
                    Name  = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("871fa652-2c1c-48f8-aedd-a6708089d5a7"),
                    Name  = "Hard"
                }
            };

            //Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);


            //Seed data for Regions
            var regions = new List<Region>() { 
            new Region
            {
                Id = Guid.Parse("7674c000-85d1-469b-8460-5043b6fc5575"),
                Name = "AuckLand",
                Code = "AKL",
                RegionImageUrl = "https://allasfileserver.s3.amazonaws.com/productos_fotos/thumbnails/01-200104-0410M_1_1.png"
            },
                        new Region
            {
                Id = Guid.Parse("52636623-dd18-4067-b6a0-03cea9aaf7c2"),
                Name = "TEGUCIGALPA",
                Code = "TGU",
                RegionImageUrl = "https://allasfileserver.s3.amazonaws.com/productos_fotos/thumbnails/01-200104-0410M_2_2.png"
            },
                                                new Region
            {
                Id = Guid.Parse("3e23d63a-1df4-4303-87a2-baa4653f846c"),
                Name = "SAN PEDRO SULA",
                Code = "SPS",
                RegionImageUrl = null
            }

            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}