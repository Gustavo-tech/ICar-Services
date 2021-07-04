using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ICar.API.Auth
{
    internal static class ValidationParametersGenerator
    {
        internal static TokenValidationParameters GenerateTokenValidationParameters()
        {
            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret.key)),
                ValidateIssuer = false,
                ValidateAudience = false,
            };
        }
    }
}
