using DAL.Entities;

namespace DAL.IRepository
{
    public interface ICustomerRepo : IRepository<Customer>
    {
        Task<ICollection<Customer>> GetAllCustomers();
        Task<Customer?> GetCustomerById(int id);
        Task DeleteCustomer(int id);
    }
}
