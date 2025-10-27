using Kometha.API.Models.Domain;

namespace Kometha.API.Repositories
{
    public interface IWalkRepository
    {
        Task<IEnumerable<Walk>> GetAllAsync(int pageNumber, int pageSize, string? filterOn, string? filterQuery, string? sortBy, bool? isAscendingg);
        Task<Walk?> GetByIdAsync(Guid id);
        Task<Walk> CreateAsync(Walk walk);
        Task<Walk?> UpdateAsync(Guid id, Walk walk);
        Task<Walk?> DeleteAsync(Guid id);
    }
}
