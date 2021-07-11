using ICar.IdentityServer.Token.Contracts;
using ICar.Infrastructure.Database.Models;
using ICar.Infrastructure.Database.Models.Abstracts;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace ICar.IdentityServer.Token
{
    public class JwtService : ITokenService
    {
        private readonly string _key;
        public JwtService(IConfiguration configuration)
        {
            _key = configuration["JwtKey"];
        }

        public string GenerateToken(User entity)
        {
            JwtSecurityTokenHandler tokenHandler = new();
            byte[] key = Encoding.ASCII.GetBytes(_key);
            SecurityTokenDescriptor descriptor = new()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, entity.UserName),
                    new Claim(ClaimTypes.Email, entity.Email),
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            SecurityToken token = tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
