using DAL.Entities;
using DAL.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class ColorRepo : Repository<Color>, IColorRepo
    {
        private readonly DBContext _context;

        public ColorRepo(DBContext context) : base(context)
        {
            _context = context;
        }
    }
}
