using ICar.Data.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Data.Queries.Contracts
{
    public interface IUserRepository
    {
        List<User> GetUsers(int? quantity);
        User GetUserByEmail(string email);
        User GetUserByCpf(string cpf);
        Task InsertUser(User user, bool isAdmin = false);
    }
}
