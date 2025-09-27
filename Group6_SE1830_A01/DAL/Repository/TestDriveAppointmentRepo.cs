using DAL.Entities;
using DAL.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class TestDriveAppointmentRepo : Repository<TestDriveAppointment>, ITestDriveAppointmentRepo 
    {
        private readonly DBContext _context;

        public TestDriveAppointmentRepo(DBContext context) : base(context)
        {
            _context = context;
        }
    }
}
