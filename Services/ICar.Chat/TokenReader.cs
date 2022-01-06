using ICar.Chat.Hubs.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace ICar.Chat
{
    public class TokenReader : ITokenReader
    {
        public string ReadClaimValue(string token, string type)
        {
            if (string.IsNullOrWhiteSpace(token))
                return null;

            JwtSecurityTokenHandler tokenHandler = new();
            JwtSecurityToken securityToken = tokenHandler.ReadJwtToken(token);

            return securityToken.Claims.FirstOrDefault(x => x.Type == type).Value;
        }
    }
}
