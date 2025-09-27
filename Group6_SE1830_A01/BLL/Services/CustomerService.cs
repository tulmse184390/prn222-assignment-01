using BLL.IServices;
using DAL.Entities;
using DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepo _customerRepo;
        public CustomerService(ICustomerRepo customerRepo) => _customerRepo = customerRepo;

        public async Task<ICollection<Customer>> GetAllCustomers()
            => await _customerRepo.GetAllCustomers();

        public async Task<Customer?> GetCustomerById(int id)
            => await _customerRepo.GetCustomerById(id);

        public async Task<int> CreateCustomer(Customer customer)
        {
            var c = await _customerRepo.AddAsync(customer);
            await _customerRepo.SaveAsync();
            return c.CustomerId;
        }

        public async Task UpdateCustomer(Customer customer)
        {
            _customerRepo.Update(customer);
            await _customerRepo.SaveAsync();
        }

        public async Task DeleteCustomer(int id)
        {
            await _customerRepo.DeleteCustomer(id);
        }
    }
}
