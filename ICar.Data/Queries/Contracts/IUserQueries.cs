using ICar.Data.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Data.Queries.Contracts
{
    public interface IUserQueries
    {
        Task<List<User>> GetUsers(int? quantity);
        Task<List<User>> GetUserByEmail(string email);
        Task<List<User>> GetUserByCpf(string cpf);
        Task InsertUser(User user, bool isAdmin = false);
    }
}
