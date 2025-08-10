using Kometha.API.Models.Domain;

namespace Kometha.API.Repositories
{
    public interface IWalkRepository
    {
        Task<List<Walk>> GetAllAsync();
        Task<Walk?> GetByIdAsync(Guid id);
        Task<Walk> CreateAsync(Walk walk);
    }
}
