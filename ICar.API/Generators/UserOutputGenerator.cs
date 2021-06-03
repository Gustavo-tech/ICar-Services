using ICar.Infrastructure.Models;
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
                UserCars = user.UserCars
                .Select(x => new {
                    x.Plate,
                    x.Maker,
                    x.Model,
                    x.City.Name,
                    x.AcceptsChange,
                    x.IsArmored,
                    x.IpvaIsPaid,
                    x.KilometersTraveled,
                    x.MakeDate,
                    x.MakedDate,
                    x.NumberOfViews,
                    x.Color,
                    x.GasolineType,
                    x.TypeOfExchange,
                    x.Price
                }),
                UserLogins = user.UserLogins.Select(x => x.Time).ToList(),
                UserNews = user.UserNews.Select(x => new
                {
                    x.Title,
                    x.Text,
                    x.CreatedOn,
                    x.LastUpdate
                })
            };
        }
    }
}
