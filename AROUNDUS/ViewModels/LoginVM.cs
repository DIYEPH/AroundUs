using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AROUNDUS.ViewModels
{
    public class LoginVM
    {
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required, PasswordPropertyText]
        public string Password { get; set; } = null!;
    }
}
