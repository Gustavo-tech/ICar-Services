using ICar.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Data.Queries.Contracts {
    interface INewsQueries {
        List<News> GetNews(int? quantity);
        void InsertNews(News news, bool userIsCompany = false);
    }
}
