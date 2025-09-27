using DAL.Entities;
using DAL.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class OrderRepo : Repository<Order>, IOrderRepo
    {
        private readonly DBContext _context;

        public OrderRepo(DBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<Order>> GetAllOrders()
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Staff)
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Version)
                .ThenInclude(v => v.Model)
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Color)
                .ToListAsync();
        }
    }
}
