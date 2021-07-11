﻿using ICar.API.Auth.Contracts;
using ICar.Infrastructure.Database.Models.Abstracts;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace ICar.API.Auth
{
    public class JwtService : IAuthService
    {
        private readonly string _key;
        public JwtService(IConfiguration configuration)
        {
            _key = configuration["JwtKey"];
        }

        public string GenerateToken(Entity entity)
        {
            JwtSecurityTokenHandler tokenHandler = new();
            byte[] key = Encoding.ASCII.GetBytes(_key);
            SecurityTokenDescriptor descriptor = new()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, entity.Name),
                    new Claim(ClaimTypes.Email, entity.Email),
                    new Claim(ClaimTypes.Role, entity.Role)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            SecurityToken token = tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool ValidateToken(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new();
                ValidationParametersGenerator tokenValidation = new(_key);
                SecurityToken validatedToken;

                IPrincipal principal = tokenHandler.ValidateToken(token, 
                    tokenValidation.GenerateTokenValidationParameters(), out validatedToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}