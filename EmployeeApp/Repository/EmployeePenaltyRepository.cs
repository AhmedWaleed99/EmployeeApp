using EmployeeApp.Models;

namespace EmployeeApp.Repository
{
    public class EmployeePenaltyRepository : IEmployeePenalty
    {

        AppDBContext context;
        public EmployeePenaltyRepository(AppDBContext _context)
        {
            context = _context;
        }
        public void Add(EmployeePenalty employeePenalty)
        {
            context.Add(employeePenalty);
        }

        public void Delete(int id)
        {
            context.EmployeePenalty.Remove(GetById(id));
        }

        public List<EmployeePenalty> GetAll()
        {
            return context.EmployeePenalty.ToList();
        }

        public EmployeePenalty GetById(int id)
        {
            return context.EmployeePenalty.FirstOrDefault(e => e.ID == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(EmployeePenalty employeePenalty)
        {
            context.Update(employeePenalty);
        }
    }
}
