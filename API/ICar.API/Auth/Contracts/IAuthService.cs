﻿using ICar.Infrastructure.Database.Models.Abstracts;

namespace ICar.API.Auth.Contracts
{
    public interface IAuthService
    {
        string GenerateToken(Entity entity);
        bool ValidateToken(string token);
    }
}