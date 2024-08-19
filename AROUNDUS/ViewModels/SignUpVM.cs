using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AROUNDUS.ViewModels
{
    public class SignUpVM
    {
        [Required]
        public string FirstName { get; set; } = null!;

        public string MiddleName { get; set; } = null!;
        [Required]
        public string? LastName { get; set; } = null!;
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required, PasswordPropertyText]
        public string Password { get; set; } = null!;
        [Required, PasswordPropertyText]
        public string PasswordConfirmed { get; set; } = null!;
    }
}
