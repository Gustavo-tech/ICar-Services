using ICar.Data.Models.Entities.Accounts;
using ICar.Data.Models.Entities.Logins;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByCpfAsync(string cpf);
        Task<List<UserLogin>> GetUserLoginsAsync(string cpf);
    }
}
