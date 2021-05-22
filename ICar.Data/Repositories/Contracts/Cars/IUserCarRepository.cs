using ICar.Data.Models.Entities.Cars;
using System.Threading.Tasks;

namespace ICar.Data.Repositories.Contracts
{
    public interface IUserCarRepository
    {
        Task<UserCar> GetUserCarByCpfAsync(string cpf);
    }
}
