using ICar.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Data.Queries.Contracts
{
    public interface ICompanyQueries
    {
        public List<Company> GetCompanies(int? quantity = null);
    }
}
