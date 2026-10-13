using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.ViewModel
{
    public class DepartmentViewModel
    {
        
        public int ID { get; set; }
        [Required]
        [DisplayName("Department Name")]
        [MaxLength(50)]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        [DisplayName("Manager Name")]
        [MaxLength(50)]
        [MinLength(2)]
        public string ManagerName { get; set; }
        public bool Status { get; set; }
    }
}
