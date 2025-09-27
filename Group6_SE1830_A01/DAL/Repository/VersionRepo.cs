using DAL.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class VersionRepo : Repository<Entities.Version>, IVersionRepo    
    {
        private readonly DBContext _context;

        public VersionRepo(DBContext context) : base(context)
        {
            _context = context;
        }
    }
}
