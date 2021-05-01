using ICar.Data.Models.Entities;
using ICar.Data.Models.EntitiesInSystem;
using ICar.Data.ViewModels.News;
using System.Collections.Generic;

namespace ICar.Data.Queries.Contracts
{
    public interface INewsQueries
    {
        List<NewsInSystem> GetNews(int? quantity = null);
        void InsertNews(News news, bool userIsCompany = false);
        void UpdateNews(int id, UpdatedNews news);
        void DeleteNews(int id);
    }
}
