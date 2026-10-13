using EmployeeApp.Models;

namespace EmployeeApp.Repository
{
    public interface IDepartmentRepository
    {
        //CRUD

        public void Add(Department department);

        public List<Department> GettAll();
        public Department GetByID(int id);
        public List<Department> GetAllByID(int id);
       

        public void Update(Department department);

        public void Save();
    }
}
