using DAL.Entities;

namespace DAL.IRepository
{
    public interface IStaffRepo : IRepository<Staff>
    {
        Task<Staff?> GetStaffByEmail(string email);
    }
}
