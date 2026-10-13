namespace EmployeeApp.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
