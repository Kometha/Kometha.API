namespace Kometha.API.Dataa
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Defines the <see cref="KomethaAuthDBContext" />
    /// </summary>
    public class KomethaAuthDBContext : IdentityDbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KomethaAuthDBContext"/> class.
        /// </summary>
        /// <param name="options">The options<see cref="DbContextOptions{KomethaAuthDBContext}"/></param>
        public KomethaAuthDBContext(DbContextOptions<KomethaAuthDBContext> options) : base(options)
        {
        }

        /// <summary>
        /// The OnModelCreating
        /// </summary>
        /// <param name="builder">The builder<see cref="ModelBuilder"/></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "d5613a61-a75a-4e80-9be5-86e4bf14b8ea";

            var writerRoleId = "e0ae86d3-0ba6-426e-a886-9bb075e7f449";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id = writerRoleId,
                    ConcurrencyStamp = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
