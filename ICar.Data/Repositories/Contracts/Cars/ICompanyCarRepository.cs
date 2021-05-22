using ICar.Data.Models.Entities.Cars;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Data.Repositories.Contracts
{
    public interface ICompanyCarRepository
    {
        Task<List<CompanyCar>> GetCompanyCarByCnpjAsync(string cnpj);
    }
}
