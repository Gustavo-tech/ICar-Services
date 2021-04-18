namespace ICar.API.ViewModels {
    public class NewUser {
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string City { get; set; }

        public NewUser(string cpf, string name, string email, string password, string city) {
            Cpf = cpf;
            Name = name;
            Email = email;
            Password = password;
            City = city;
        }
    }
}
