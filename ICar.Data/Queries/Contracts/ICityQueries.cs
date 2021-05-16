using ICar.Data.Models.Entities;
using System.Threading.Tasks;

namespace ICar.Data.Queries.Contracts
{
    public interface ICityQueries
    {
        public City GetCityById(int id);
    }
}
