using ICar.Data.Models.Entities;
using System;

namespace ICar.Data.Models.EntitiesInSystem
{
    public class NewsInSystem : News
    {
        public int Id { get; }
        public DateTime LastUpdate { get; set; }
        public string UserCpf { get; set; }
        public string CompanyCnpj { get; set; }

        public NewsInSystem(string title, string text, string userCpf, string companyCnpj)
            : base(title, text, companyCnpj, userCpf)
        {
            Title = title;
            Text = text;
            UserCpf = userCpf;
            CompanyCnpj = companyCnpj;
        }

        public NewsInSystem(int id, string title, string text, DateTime last_update, string user_cpf, string company_cnpj)
            : base(title, text, user_cpf, company_cnpj)
        {
            Id = id;
            Title = title;
            Text = text;
            LastUpdate = last_update;
            UserCpf = user_cpf;
            CompanyCnpj = company_cnpj;
        }
    }
}
