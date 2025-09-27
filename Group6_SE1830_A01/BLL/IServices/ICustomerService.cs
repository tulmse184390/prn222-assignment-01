using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IServices
{
    public interface ICustomerService
    {
        Task<ICollection<Customer>> GetAllCustomers();
        Task<Customer?> GetCustomerById(int id);
        Task<int> CreateCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
        Task DeleteCustomer(int id);
    }
}
