using ICar.Data.Models.EntitiesInSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Data.Queries.Contracts
{
    public interface ICityQueries
    {
        public CityInSystem GetCityById(int id);
    }
}
