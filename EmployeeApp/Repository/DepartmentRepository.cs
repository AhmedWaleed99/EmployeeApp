using EmployeeApp.Models;

namespace EmployeeApp.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        AppDBContext context;
        public DepartmentRepository(AppDBContext _context)
        {
            context = _context; 
        }
        public void Add(Department department)
        {
            context.Add(department);
        }

        public List<Department> GetAllByID(int id)
        {
            return context.Department.Where(d => d.ID == id).ToList();
        }

        public Department GetByID(int id)
        {
            return context.Department.FirstOrDefault(d => d.ID == id);
        }

        public List<Department> GettAll()
        {
            return context.Department.ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Department department)
        {
            context.Update(department);
        }

     
    }
}
