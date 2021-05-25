using ICar.Data.Models.Entities;
using ICar.Data.Models.Entities.Accounts;
using ICar.Data.Models.Entities.News;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Data
{
    public class DataInjector
    {
        private readonly DatabaseContext _dbContext;

        private List<User> UsersReference = new List<User>
        {
            new User("129.890.870-09", "Gustavo", "gustavo@gmail.com", "asdasd", "Campinas"),
            new User("902.721.893-32", "Camila", "camila@gmail.com", "asdasd", "Campinas"),
            new User("789.123.280-90", "João", "joao@gmail.com", "asdasd", "Campinas"),
        };


        private List<Company> CompaniesReference = new List<Company>
        {
            new Company("06.990.590/0001-23", "Google", "google@gmail.com", "Google&", null),
            new Company("60.316.817/0001-03", "Microsoft", "microsoft@gmail.com", "Microsoft&", null)
        };

        public DataInjector(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        private async Task InsertInitialCompaniesAsync()
        {
            try
            {
                if (await _dbContext.Companies.AnyAsync() == false)
                {
                    await _dbContext.Companies.AddRangeAsync(CompaniesReference);
                    await _dbContext.SaveChangesAsync();
                };
            }
            catch (Exception)
            {
                return;
            }
        }

        private async Task InsertInitialNewsAsync()
        {
            try
            {
                if (await _dbContext.UserNews.AnyAsync() == false)
                {
                    UserNews userNews = new UserNews("New Honda Civic is beautiful", "AAAAAAAAA", UsersReference[0]);
                    await _dbContext.UserNews.AddAsync(userNews);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private async Task InsertInitialCitiesAsync()
        {
            if (await _dbContext.Cities.AnyAsync() == false)
            {
                try
                {
                    List<City> cities = new List<City>
                    {
                        new City(1, "Vancouver"),
                        new City(2, "Valinhos"),
                        new City(3, "Campinas"),
                        new City(4, "Vinhedo"),
                        new City(5, "Toronto"),
                    };

                    await _dbContext.Cities.AddRangeAsync(cities);
                    await _dbContext.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        private async Task InsertInitialUsersAsync()
        {
            try
            {
                if (await _dbContext.Users.AnyAsync() == false)
                {
                    await _dbContext.AddRangeAsync(UsersReference);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        public async Task InsertInitialDataAsync()
        {
            await InsertInitialCitiesAsync();
            await InsertInitialUsersAsync();
            await InsertInitialCompaniesAsync();
        }
    }
}
