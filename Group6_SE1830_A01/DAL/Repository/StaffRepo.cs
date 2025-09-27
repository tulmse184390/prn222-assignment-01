using DAL.Entities;
using DAL.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class StaffRepo : Repository<Staff>, IStaffRepo
    {
        private readonly DBContext _context;

        public StaffRepo(DBContext context) : base(context)
        {
            _context = context;
        }
    }
}
