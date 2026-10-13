using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApp.Models
{
    [Table("employees")]
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address  { get; set; }
        public double Salary  { get; set; }
        public string Phone  { get; set; }

        public bool Status { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }

        public Department Department { get; set; }

        public virtual ICollection<EmployeePenalty> EmployeesPenalties { get; set; }
    }
}
