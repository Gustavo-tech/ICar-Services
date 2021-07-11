using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ICar.IdentityServer.Token
{
    public class ValidationParametersGenerator
    {
        private readonly string _key;

        public ValidationParametersGenerator(IConfiguration configuration)
        {
            _key = configuration["JwtKey"];
        }

        public ValidationParametersGenerator(string key)
        {
            _key = key;
        }

        public TokenValidationParameters GenerateTokenValidationParameters()
        {
            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key)),
                ValidateIssuer = false,
                ValidateAudience = false,
            };
        }
    }
}
