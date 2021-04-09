using ICar.Data.Models.Abstract;

namespace ICar.API.Auth.Contracts
{
    public interface IAuthService
    {
        string GenerateToken(Entity entity);
        bool ValidateToken(string token);
    }
}
