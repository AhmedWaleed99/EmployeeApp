using EmployeeApp.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [DisplayName("First Name")]
        [MaxLength(50, ErrorMessage = "Max Lenght 50")]
        [MinLength(2, ErrorMessage = "Min Lenght 2")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        [MaxLength(50, ErrorMessage = "Max Lenght 50")]
        [MinLength(2, ErrorMessage = "Min Lenght 2")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("User Name")]
        [MaxLength(50, ErrorMessage = "Max Lenght 50")]
        [MinLength(2, ErrorMessage = "Min Lenght 2")]
        public string UserName { get; set; }
        [Required]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}
