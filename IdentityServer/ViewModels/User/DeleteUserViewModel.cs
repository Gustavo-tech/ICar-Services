using System.ComponentModel.DataAnnotations;

namespace ICar.IdentityServer.ViewModels.User
{
    public class DeleteUserViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; }

        public DeleteUserViewModel(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
