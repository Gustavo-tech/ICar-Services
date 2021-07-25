using ICar.Infrastructure.Database.Models;
using System;
using System.Collections.Generic;

namespace ICar.API.Generators
{
    internal static class NewsOutputFactory
    {
        internal static dynamic GenerateUserNewsOutput(News news)
        {
            return new
            {
                news.Id,
                PublishedBy = news.Owner.Email,
                news.Title,
                news.Text,
                news.LastUpdate,
                news.CreatedOn
            };
        }

        internal static dynamic[] GenerateUserNewsOutput(List<News> news)
        {
            dynamic[] output = new dynamic[news.Count];
            try
            {
                for (int x = 0; x < news.Count; x++)
                {
                    output[x] = new
                    {
                        news[x].Id,
                        PublishedBy = news[x].Owner.Email,
                        news[x].Title,
                        news[x].Text,
                        news[x].LastUpdate,
                        news[x].CreatedOn
                    };
                }

                return output;
            }
            catch (Exception)
            {
                return output;
            }
        }
    }
}
