using EmployeeApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        AppDBContext context;
        public EmployeeRepository(AppDBContext _context)
        {
            context = _context;    
        }
        public void Add(Employee employee)
        {
            context.Add(employee);
        }

        public void Delete(int id)
        {
            context.Employee.Remove(GetById(id));
        }

        public List<Employee> GetAll()
        {
           return context.Employee.ToList();
        }

        public Employee GetAllInformation(int id)
        {
            return context.Employee.Include(e => e.EmployeesPenalties).ThenInclude(p => p.PenaltyType).FirstOrDefault(e => e.ID == id);
        }

        public List<Employee> GetAllWithDepartment()
        {
            return context.Employee.Include(e => e.Department).ToList();
        }

        public List<Employee> GetAllWithDepartmentByID(int id)
        {
            return context.Employee.Include(e => e.Department).Where(e => e.Department.ID == id).ToList();
        }

        public Employee GetById(int id)
        {
            return context.Employee.FirstOrDefault(e => e.ID == id);
        }

        public List<Employee> GetEmployeeByID(int id)
        {
            return context.Employee.Where(e => e.ID == id).ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Employee employee)
        {
            context.Update(employee);
        }
    }
}
