using EmployeeApp.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApp.ViewModel
{
    public class EmployeeViewModel
    {
        public int ID { get; set; }
        [Required]
        [DisplayName("Full Name")]
        [MaxLength(50)]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(2)]
        public string Address { get; set; }
        [Required]
        public double Salary { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public bool Status { get; set; }

        
        public int DepartmentID { get; set; }

        public List<Department>? Departments { get; set; }
    }
}
