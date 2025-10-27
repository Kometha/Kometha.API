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

        public async Task<IEnumerable<Walk>> GetAllAsync(int pageNumber, int pageSize, string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool? isAscending = true)
        {
            var walks = dBContext.Walks.Include("Difficulty").Include("Region").AsQueryable();

            //Filtering
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                }                
            }

            // Sorting
            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = (isAscending ?? true)
                        ? walks.OrderBy(x => x.Name)
                        : walks.OrderByDescending(x => x.Name);
                }
                else if (sortBy.Equals("LengthInKm", StringComparison.OrdinalIgnoreCase))
                {
                    walks = (isAscending ?? true)
                        ? walks.OrderBy(x => x.LengthInKm)
                        : walks.OrderByDescending(x => x.LengthInKm);
                }
            }

            //Pagination 
            var skipResults = (pageNumber - 1) * pageSize;            

            return await walks.Skip(skipResults).Take(pageSize).ToListAsync();            
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await dBContext.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await dBContext.Walks.FindAsync(id);

            if (existingWalk == null)
            {
                return null;
            }
            
            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.DifficultyId = walk.DifficultyId;
            existingWalk.RegionId = walk.RegionId;

            await dBContext.SaveChangesAsync();
            return existingWalk;

        }
        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var existingWalk = await dBContext.Walks.FindAsync(id);

            if (existingWalk == null)
            {
                return null;
            }

            dBContext.Walks.Remove(existingWalk);
            await dBContext.SaveChangesAsync();

            return existingWalk;
        }
    }
}
