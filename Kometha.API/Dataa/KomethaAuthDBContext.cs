using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kometha.API.Dataa
{
    public class KomethaAuthDBContext : IdentityDbContext
    {
        public KomethaAuthDBContext(DbContextOptions<KomethaAuthDBContext> options) : base(options)
        {
        }        
    }
}
