using EmployeeApp.Models;

namespace EmployeeApp.Repository
{
    public interface IEmployeeRepository
    {
        public void Add(Employee employee);

        public List<Employee> GetAll();
        public List<Employee> GetAllWithDepartment();
        public List<Employee> GetAllWithDepartmentByID(int id);
        public List<Employee> GetEmployeeByID(int id);
        public Employee GetById(int id);
        public Employee GetAllInformation(int id);

        public void Update(Employee employee);

        public void Save();

        public void Delete(int id );
    }
}
