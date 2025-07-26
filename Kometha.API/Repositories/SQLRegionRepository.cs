using Kometha.API.Dataa;
using Kometha.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Kometha.API.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly KomethaDBContext dBContext;
        public SQLRegionRepository(KomethaDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await dBContext.Regions.ToListAsync();
        }
    }
}
