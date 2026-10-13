using EmployeeApp.Models;

namespace EmployeeApp.Repository
{
    public interface IEmployeePenalty
    {
        public void Add(EmployeePenalty employeePenalty);
        public void Update(EmployeePenalty employeePenalty);
        public void Delete(int id);
        public List<EmployeePenalty> GetAll();
     
        public EmployeePenalty GetById(int id);
        public void Save();
    }
}
