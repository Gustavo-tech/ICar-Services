using System.Collections.Generic;

namespace ICar.Data.Models.Entities
{
    public class Company
    {
        public string Cnpj { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
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
