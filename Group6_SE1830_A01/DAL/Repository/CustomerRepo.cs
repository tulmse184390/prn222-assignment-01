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
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Customer?> GetCustomerById(int id)
        {
            return await _context.Customers
                .Include(c => c.Orders)
                .FirstOrDefaultAsync(c => c.CustomerId == id);
        }

        public async Task DeleteCustomer(int id)
        {
            var customer = await _context.Customers
                .Include(c => c.Orders)
                .FirstOrDefaultAsync(c => c.CustomerId == id);

            if (customer != null)
            {
                // Xóa kèm orders nếu cần
                if (customer.Orders.Any())
                    _context.Orders.RemoveRange(customer.Orders);

                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
