using ICar.Data.Models.Entities.Accounts;
using ICar.Data.Models.Entities.Logins;
using ICar.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _dbContext;

        public UserRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUserByCpfAsync(string cpf)
        {
            return await _dbContext.Users.Where(x => x.Cpf == cpf).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<List<UserLogin>> GetUserLoginsAsync(string cpf)
        {
            return await _dbContext.UserLogins.Where(x => x.UserCpf == cpf).ToListAsync();
        }
    }
}
