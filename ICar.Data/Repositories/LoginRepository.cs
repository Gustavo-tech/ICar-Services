using ICar.Infrastructure.Models;
using ICar.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Repositories
{
    public class LoginRepository : ILoginRepository<Login>
    {
        private readonly DatabaseContext _dbContext;

        public LoginRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Login>> GetAllLogins()
        {
            return await _dbContext.UserLogins.ToListAsync();
        }
    }
}
