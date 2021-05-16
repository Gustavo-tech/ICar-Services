using ICar.Data.Models.Entities;

using ICar.Data.ViewModels.News;
using System.Collections.Generic;

namespace ICar.Data.Queries.Contracts
{
    public interface INewsQueries
    {
        List<News> GetNews(int? quantity = null);
        void InsertNews(ViewModels.News.NewNews news, bool userIsCompany = false);
        void UpdateNews(int id, UpdatedNews news);
        void DeleteNews(int id);
    }
}
