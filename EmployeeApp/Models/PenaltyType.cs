namespace EmployeeApp.Models
{
    public class PenaltyType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double DefaultAmount { get; set; }
        public bool IsActive { get; set; } = true; 

        public virtual ICollection<EmployeePenalty> employeesPenalties { get; set; }
    }
}
