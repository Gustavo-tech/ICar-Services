using ICar.Data.Models.Entities.News;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Data.Repositories.Interfaces
{
    public interface IUserNewsRepository
    {
        Task<List<UserNews>> GetUserNewsAsync();
        Task InsertUserNewsAsync(UserNews news);
        Task UpdateUserNewsAsync(UserNews news);
        Task DeleteUserNewsAsync(int id);
    }
}
