using ICar.Data.Models.Abstracts;
using System.Collections.Generic;

namespace ICar.Data.Models.Entities
{
    public class Company : Entity
    {
        public string Cnpj { get; set; }
        public List<string> Cities { get; set; }

        public Company(string cnpj, string name, string email, string password, List<string> cities)
        {
            Cnpj = cnpj;
            Name = name;
            Email = email;
            Password = password;
            Cities = cities;
        }
    }
}
