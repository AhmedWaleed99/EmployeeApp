using EmployeeApp.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApp.ViewModel
{
    public class EmployeePenaltyViewModel
    {
        public int ID { get; set; }
        [Required]
        [DisplayName("Employee")]
        public int EmployeeID { get; set; }
        [Required]
        [DisplayName("Penalty")]
        public int PenaltyTypeID { get; set; }
        [Required]
        [DisplayName("Manager")]
        public string ManagerID { get; set; }
        [Required]
        [Range(20,2000)]
        public double Amount { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string Notes { get; set; }

        public List<Employee>?  EmployeeList { get; set; }
        public List<PenaltyType>? PenaltyTypeList { get; set; }
    }
}
