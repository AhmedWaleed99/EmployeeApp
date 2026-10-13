using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.ViewModel
{
    public class RoleViewModel
    {
        [Required]
        [DisplayName("Role Name")]
        public string Name { get; set; }
    }
}
