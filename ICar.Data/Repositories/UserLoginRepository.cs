using ICar.Infrastructure.Models;
using ICar.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Repositories
{
    public class UserLoginRepository : ILoginRepository<UserLogin>
    {
        private readonly DatabaseContext _dbContext;

        public UserLoginRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UserLogin>> GetAllLogins()
        {
            return await _dbContext.UserLogins.ToListAsync();
        }
    }
}
