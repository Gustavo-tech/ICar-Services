﻿using ICar.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Database.Repositories.Interfaces
{
    public interface ILoginRepository
    {
        Task<List<Login>> GetAllLogins();
        Task AddLogin(Login login);
    }
}
