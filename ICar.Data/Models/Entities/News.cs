using ICar.Data.Models.Abstracts;
using System;

namespace ICar.Data.Models.Entities
{
    public class News : AbstractNews
    {
        public int Id { get; }
        public DateTime LastUpdate { get; set; }
        public string UserCpf { get; set; }
        public string CompanyCnpj { get; set; }

        public News(string title, string text, string userCpf, string companyCnpj)
        {
            Title = title;
            Text = text;
            UserCpf = userCpf;
            CompanyCnpj = companyCnpj;
        }

        public News(int id, string title, string text, DateTime lastUpdate, string userCpf, string companyCnpj)
        {
            Id = id;
            Title = title;
            Text = text;
            LastUpdate = lastUpdate;
            UserCpf = userCpf;
            CompanyCnpj = companyCnpj;
        }
    }
}
