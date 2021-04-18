using ICar.Data.Models;
using System.Collections.Generic;

namespace ICar.Data.Queries.Contracts {
    public interface IUserQueries {
        List<User> GetUsers(int? quantity);
        User GetUserByEmail(string email);
        void InsertUser(User user);
    }
}
