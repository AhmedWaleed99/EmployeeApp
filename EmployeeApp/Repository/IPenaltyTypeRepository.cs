using EmployeeApp.Models;

namespace EmployeeApp.Repository
{
    public interface IPenaltyTypeRepository
    {
        public void Add(PenaltyType penaltyType);

        public List<PenaltyType> GetAll();
        public List<PenaltyType> GetByID(int id);
        public PenaltyType GetById(int id);

        public void Update(PenaltyType penaltyType);

        public void Save();
    }
}
