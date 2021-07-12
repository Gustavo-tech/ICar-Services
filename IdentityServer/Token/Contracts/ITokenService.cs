using ICar.Infrastructure.Database.Models;
using ICar.Infrastructure.Database.Models.Abstracts;

namespace ICar.IdentityServer.Token.Contracts
{
    public interface ITokenService
    {
        string GenerateToken(User entity);
    }
}
