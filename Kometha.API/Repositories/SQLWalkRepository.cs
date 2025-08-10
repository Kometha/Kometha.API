using Kometha.API.Dataa;
using Kometha.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Kometha.API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly KomethaDBContext dBContext;

        public SQLWalkRepository(KomethaDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dBContext.Walks.AddAsync(walk);

            await dBContext.SaveChangesAsync();

            return walk;
        }
        public async Task<List<Walk>> GetAllAsync()
        {
            return await dBContext.Walks.ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await dBContext.Walks.FindAsync(id);
        }
    }
}
