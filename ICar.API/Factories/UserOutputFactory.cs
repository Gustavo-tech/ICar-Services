using ICar.Infrastructure.Models;
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
                user.Name,
                user.Email,
                user.AccountCreationDate,
                user.Role,
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
                    users[i].Name,
                    users[i].Email,
                    users[i].AccountCreationDate,
                    users[i].Role,
                };
            }

            return output;
        }
    }
}
