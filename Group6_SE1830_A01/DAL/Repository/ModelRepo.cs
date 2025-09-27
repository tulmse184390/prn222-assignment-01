using DAL.Entities;
using DAL.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class ModelRepo : Repository<Model>, IModelRepo
    {
        private readonly DBContext _context;

        public ModelRepo(DBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<Model>> GetAllModels()
        {
            return await _context.Models
                .Include(m => m.Versions)
                .ThenInclude(v => v.Colors)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Model?> GetModelById(int id)
        {
            return await _context.Models
                .Include(m => m.Versions)
                .ThenInclude(v => v.Colors)
                .FirstOrDefaultAsync(m => m.ModelId == id);
        }

        public async Task DeleteModel(int id)
        {
            var model = await _context.Models
                .Include(m => m.Versions)
                .ThenInclude(v => v.Colors)
                .FirstOrDefaultAsync(m => m.ModelId == id);

            if (model != null)
            {
                // Xóa kèm các version và color liên quan
                foreach (var version in model.Versions)
                {
                    _context.Colors.RemoveRange(version.Colors);
                }
                _context.Versions.RemoveRange(model.Versions);

                _context.Models.Remove(model);
                await _context.SaveChangesAsync();
            }
        }
    }
}
