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
    }
}
