using ICar.Data.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Data.Repositories.Interfaces
{
    public interface INewsRepository
    {
        Task<List<News>> GetNewsAsync();
        Task InsertNewsAsync(News news);
        Task UpdateNewsAsync(News news);
        Task DeleteNewsAsync(int id);
    }
}
