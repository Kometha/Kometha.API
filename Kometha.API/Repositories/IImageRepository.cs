using Kometha.API.Models.Domain;

namespace Kometha.API.Repositories
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}
