using ICar.Data.Models.Entities;
using ICar.Data.Models.Entities.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByCpfAsync(string cpf);
        Task InsertUserAsync(User user);
    }
}
