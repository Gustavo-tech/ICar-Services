using ICar.Data.Models.Entities;

using System.Collections.Generic;

namespace ICar.Data.Queries.Contracts
{
    public interface IUserQueries
    {
        List<User> GetUsers(int? quantity);
        User GetUserByEmail(string email);
        User GetUserByCpf(string cpf);
        void InsertUser(User user, bool isAdmin = false);
    }
}
