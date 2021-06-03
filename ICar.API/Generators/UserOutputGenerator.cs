using ICar.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
                City = user.City.Name,
                user.Role,
                user.UserCars,
                UserLogins = user.UserLogins.Select(x => x.Time),
                UserNews = user.UserNews.Select(x => new
                {
                    x.Title,
                    x.Text,
                    x.LastUpdate,
                    x.CreatedOn
                })
            };
        }
    }
}
