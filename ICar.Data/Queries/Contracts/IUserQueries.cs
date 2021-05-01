using ICar.Data.Models.Entities;
using ICar.Data.Models.EntitiesInSystem;
using System.Collections.Generic;

namespace ICar.Data.Queries.Contracts
{
    public interface IUserQueries
    {
        List<UserInSystem> GetUsers(int? quantity);
        UserInSystem GetUserByEmail(string email);
        UserInSystem GetUserByCpf(string cpf);
        void InsertUser(User user, bool isAdmin = false);
    }
}
