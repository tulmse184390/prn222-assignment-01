using DAL.Entities;
using DAL.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class CustomerRepo : Repository<Customer>, ICustomerRepo
    {
        private readonly DBContext _context;

        public CustomerRepo(DBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<Customer>> GetAllCustomers()
        {
            return await _context.Customers
                .Include(c => c.Orders)
                .ThenInclude(o => o.OrderDetails)
                .ToListAsync();
        }

        public async Task<Customer?> GetCustomerById(int id)
        {
            return await _context.Customers
                .Include(c => c.Orders)
                .Include(c => c.TestDriveAppointments)
                .FirstOrDefaultAsync(c => c.CustomerId == id);
        }

        public async Task<int> GetTotalCustomers()
        {
            return await _context.Customers.CountAsync();
        }
    }
}
