using System.ComponentModel.DataAnnotations;

namespace Master.Models.ViewModels
{
    public class RegisterViewModel
    {

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "First name must contain only letters and spaces.")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Last name must contain only letters and spaces.")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "PASSWORD AND CONFIEM NOT MATCH")]
        public string ConfirmPassword { get; set; }

        public int Phone { get; set; }
    }
}
