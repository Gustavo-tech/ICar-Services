using System.Collections.Generic;

namespace ICar.API.ViewModels
{
    public class NewCompany
    {
        public string Cnpj { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<string> Cities { get; set; }

        public NewCompany(string cnpj, string name, string password, List<string> cities)
        {
            Cnpj = cnpj;
            Name = name;
            Password = password;
            Cities = cities;
        }
    }
}
