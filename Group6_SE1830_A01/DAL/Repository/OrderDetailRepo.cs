using DAL.Entities;
using DAL.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class OrderDetailRepo : Repository<OrderDetail> , IOrderDetailRepo
    {
        private readonly DBContext _context;

        public OrderDetailRepo(DBContext context) : base(context)
        {
            _context = context;
        }
    }
}
