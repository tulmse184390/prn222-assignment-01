using DAL.Entities;
using DAL.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class InventoryRepo : Repository<Inventory>, IInventoryRepo
    {
        private readonly DBContext _context;

        public InventoryRepo(DBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<Inventory>> GetInventory()
        {
            return await _context.Inventories
                .Include(i => i.Color)
                .Include(i => i.Version)
                .ThenInclude(v => v.Model)  
                .ToListAsync();
        }

        public async Task<int> GetTotalQuantity()
        {
            return await _context.Inventories.SumAsync(i => i.Quantity ?? 0);
        }
    }
}
