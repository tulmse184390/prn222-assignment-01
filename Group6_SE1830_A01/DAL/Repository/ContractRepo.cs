using DAL.Entities;
using DAL.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class ContractRepo : Repository<Contract>, IContractRepo 
    {
        private readonly DBContext _context;

        public ContractRepo(DBContext context) : base(context)
        {
            _context = context;
        }
    }
}
