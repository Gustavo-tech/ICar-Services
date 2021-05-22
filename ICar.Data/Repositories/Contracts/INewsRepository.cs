using ICar.Data.Models.Entities;
using ICar.Data.ViewModels.News;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Data.Queries.Contracts
{
    public interface INewsRepository
    {
        List<News> GetNews(int? quantity = null);
        Task InsertNews(NewNews news, bool userIsCompany = false);
        Task UpdateNews(int id, UpdatedNews news);
        Task DeleteNews(int id);
    }
}
