using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [DisplayName("UserName")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
