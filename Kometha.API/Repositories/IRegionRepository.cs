using Kometha.API.Models.Domain;

namespace Kometha.API.Repositories
{
    public interface IRegionRepository
    {
        //
        Task<List<Region>> GetAllAsync();
        //
    }
}
