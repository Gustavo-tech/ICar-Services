using ICar.Data.Models.Entities;
using System.Threading.Tasks;

namespace ICar.Data.Queries.Contracts
{
    public interface ICityQueries
    {
        public Task<City> GetCityById(int id);
    }
}
