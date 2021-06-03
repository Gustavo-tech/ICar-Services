using ICar.Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace ICar.API.Generators
{
    public static class UserOutputGenerator
    {
        public static dynamic GenerateUserOutput(User user)
        {
            return new
            {
                CPF = user.Cpf,
                user.Name,
                user.Email,
                user.AccountCreationDate,
                City = GeneralOutputGenerator.GenerateCityOutput(user.City),
                user.Role,
                user.UserCars,
                UserLogins = GenerateLoginTimes(user),
                user.UserNews
            };
        }

        public static dynamic[] GenerateUserOutput(List<User> users)
        {
            dynamic[] outputs = new dynamic[users.Count];

            for (int i = 0; i <= users.Count - 1; i++)
            {
                List<DateTime> userLoginTimes = GenerateLoginTimes(users[i]);
                outputs[i] = new
                {
                    CPF = users[i].Cpf,
                    users[i].Name,
                    users[i].Email,
                    users[i].AccountCreationDate,
                    City = GeneralOutputGenerator.GenerateCityOutput(users[i].City),
                    users[i].Role,
                    users[i].UserCars,
                    UserLogins = GeneralOutputGenerator.GenerateLoginsOutput(userLoginTimes),
                    users[i].UserNews
                };
            }

            return outputs;
        }

        private static List<DateTime> GenerateLoginTimes(User user)
        {
            List<DateTime> userLoginTimes = new();

            try
            {
                foreach (UserLogin login in user.UserLogins)
                {
                    userLoginTimes.Add(login.Time);
                }

                return userLoginTimes;
            }
            catch (Exception)
            {
                return userLoginTimes;
            }
        }
    }
}
