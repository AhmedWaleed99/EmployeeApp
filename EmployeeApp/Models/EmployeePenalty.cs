using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApp.Models
{
    public class EmployeePenalty
    {
        public int ID { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        [ForeignKey("PenaltyType")]
        public int PenaltyTypeID { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ManagerID { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }

        public Employee Employee { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public PenaltyType PenaltyType { get; set; }
    }
}
