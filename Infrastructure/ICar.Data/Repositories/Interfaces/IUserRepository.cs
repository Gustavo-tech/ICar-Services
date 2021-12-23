using ICar.Infrastructure.Models;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> GetUserInfo(string userId);
    }
}
