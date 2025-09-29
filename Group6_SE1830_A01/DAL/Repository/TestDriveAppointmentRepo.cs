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

        public async Task DeleteTestDriveAppointments(ICollection<TestDriveAppointment> testDriveAppointments)
        {
            _context.TestDriveAppointments.RemoveRange(testDriveAppointments);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<TestDriveAppointment>> GetAllApointments()
        {
            return await _context.TestDriveAppointments
                .Include(t => t.Customer)
                .Include(t => t.CarVersion)
                .Include(t => t.Color)
                .ToListAsync();
        }

        public async Task<ICollection<TestDriveAppointment>> GetAppointmentsInDay(DateTime date)
        {
            return await _context.TestDriveAppointments
                .Where(t => t.DateTime.Date == date.Date)
                .ToListAsync();
        }

        public async Task<ICollection<TestDriveAppointment>> GetScheduledAppointmentsInDay(DateTime date)
        {
            return await _context.TestDriveAppointments
                .Where(t => t.DateTime.Date == date.Date && t.Status == "Scheduled")
                .ToListAsync();
        }
    }
}
