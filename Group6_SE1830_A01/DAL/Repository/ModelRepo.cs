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
    }
}
