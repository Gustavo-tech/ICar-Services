
using ICar.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Data.Queries.Contracts
{
    public interface ICityQueries
    {
        public City GetCityById(int id);
    }
}
