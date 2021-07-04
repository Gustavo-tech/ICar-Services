using System;

namespace ICar.Infrastructure.Database.Models
{
    public class Login
    {
        public int? Id { get; set; }
        public string CompanyCnpj { get; set; }
        public string UserCpf { get; set; }
        public DateTime Time { get; set; }

        public Login()
        { }
    }
}
