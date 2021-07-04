using ICar.Infrastructure.Database.Models;
using System.Collections.Generic;

namespace ICar.API.Generators
{
    internal static class UserOutputFactory
    {
        internal static dynamic GenerateUserOutput(User user)
        {
            return new
            {
                CPF = user.Cpf,
                user.UserName,
                user.Email,
                user.AccountCreationDate,
                user.Role,
                AccountType = "user"
            };
        }

        internal static dynamic[] GenerateUserOutput(List<User> users)
        {
            dynamic[] output = new dynamic[users.Count];

            for (int i = 0; i < users.Count; i++)
            {
                output[i] = new
                {
                    CPF = users[i].Cpf,
                    users[i].UserName,
                    users[i].Email,
                    users[i].AccountCreationDate,
                    users[i].Role,
                    AccountType = "user"
                };
            }

            return output;
        }
    }
}
