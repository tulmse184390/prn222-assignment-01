using DAL.Entities;

namespace DAL.IRepository
{
    public interface ICustomerRepo : IRepository<Customer>
    {
        Task<int> GetTotalCustomers();
        Task<ICollection<Customer>> GetAllCustomers();
        Task<Customer?> GetCustomerById(int id); 
    }
}
