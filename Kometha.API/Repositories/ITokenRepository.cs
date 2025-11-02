using Microsoft.AspNetCore.Identity;

namespace Kometha.API.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWToken(IdentityUser user, List<string> roles);
    }
}
