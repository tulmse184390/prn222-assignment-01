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

        public async Task DeleteOrder(int id)
        {
            var order = await _context.Orders
                              .Include(o => o.OrderDetails)
                              .FirstOrDefaultAsync(o => o.OrderId == id);

            if (order != null)
            {
                _context.OrderDetails.RemoveRange(order.OrderDetails);
                _context.Orders.Remove(order);

                await _context.SaveChangesAsync();
            }
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

        public async Task<Order?> GetOrderById(int id)
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Staff)
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Version)
                .ThenInclude(v => v.Model)
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Color).FirstOrDefaultAsync(o => o.OrderId == id);
        }

        public async Task<decimal> GetRevenue()
        {
            return await _context.Orders.SumAsync(o => o.OrderDetails.Sum(od => od.FinalPrice));
        }
    }
}
