using ICar.Data.Models.Entities.Logins;
using ICar.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Data.Repositories
{
    public class UserLoginRepository : ILoginRepository<UserLogin>
    {
        private readonly DatabaseContext _dbContext;

        public UserLoginRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddLogin(UserLogin userLogin)
        {
            await _dbContext.UserLogins.AddAsync(userLogin);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<UserLogin>> GetAllLogins()
        {
            return await _dbContext.UserLogins.ToListAsync();
        }
    }
}
