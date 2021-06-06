using ICar.Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace ICar.API.Generators
{
    internal static class NewsOutputGenerator
    {
        internal static dynamic GenerateCompanyNewsOutput(News news)
        {
            return new
            {
                PublishedBy = news.CompanyCnpj,
                news.Title,
                news.Text,
                news.LastUpdate,
                news.CreatedOn
            };
        }

        internal static dynamic[] GenerateCompanyNewsOutput(List<News> news)
        {
            dynamic[] output = new dynamic[news.Count];
            try
            {
                for(int x = 0; x < news.Count; x++)
                {
                    output[x] = new
                    {
                        PublishedBy = news[x].CompanyCnpj,
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

        internal static dynamic GenerateUserNewsOutput(News news)
        {
            return new
            {
                PublishedBy = news.UserCpf,
                news.Title,
                news.Text,
                news.LastUpdate,
                news.CreatedOn
            };
        }
    }
}
