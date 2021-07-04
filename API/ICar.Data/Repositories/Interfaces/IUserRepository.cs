using ICar.Infrastructure.Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Database.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByCpfAsync(string cpf);
        Task<List<Login>> GetUserLoginsAsync(string cpf);
    }
}
