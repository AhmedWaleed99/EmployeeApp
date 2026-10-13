using EmployeeApp.Models;

namespace EmployeeApp.Repository
{
    public class PenaltyTypeRepository : IPenaltyTypeRepository
    {
        AppDBContext context;
        public PenaltyTypeRepository(AppDBContext _context)
        {
            context = _context;
        }
        public void Add(PenaltyType penaltyType)
        {
            context.Add(penaltyType);
        }

        public List<PenaltyType> GetAll()
        {
            return context.PenaltyType.ToList();
        }

        public PenaltyType GetById(int id)
        {
            return context.PenaltyType.FirstOrDefault(p => p.ID == id);
        }

        public List<PenaltyType> GetByID(int id)
        {
            return context.PenaltyType.Where(p => p.ID == id).ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(PenaltyType penaltyType)
        {
            context.Update(penaltyType);
        }
    }
}
