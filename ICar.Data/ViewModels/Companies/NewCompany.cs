using ICar.Data.Models.Abstracts;
using System.Collections.Generic;

namespace ICar.Data.ViewModels.Companies
{
    public class NewCompany : Entity
    {
        public string Cnpj { get; set; }
        public List<string> Cities { get; set; }

        public NewCompany(string cnpj, string name, string email, string password, List<string> cities)
        {
            Cnpj = cnpj;
            Name = name;
            Email = email;
            Password = password;
            Cities = cities;
        }
    }
}
