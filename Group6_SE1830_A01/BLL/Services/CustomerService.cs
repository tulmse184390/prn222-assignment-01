using AutoMapper;
using BLL.BusinessObjects;
using BLL.IServices;
using DAL.IRepository;

namespace BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepo _customerRepo;
        private readonly ITestDriveAppointmentRepo _testDriveAppointmentRepo;

        public CustomerService(IMapper mapper, ICustomerRepo customerRepo, ITestDriveAppointmentRepo testDriveAppointmentRepo)
        {
            _mapper = mapper;
            _customerRepo = customerRepo;
            _testDriveAppointmentRepo = testDriveAppointmentRepo;
        }

        public async Task CreateCustomer(ViewCustomerCreate customer)
        {
            await _customerRepo.AddAsync(_mapper.Map<DAL.Entities.Customer>(customer));
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            var customer = await _customerRepo.GetCustomerById(id);

            if (customer == null || ((customer.Orders != null && customer.Orders.Any())))
            {
                return false;
            }

            if (customer.TestDriveAppointments != null && customer.TestDriveAppointments.Any())
            {
                await _testDriveAppointmentRepo.DeleteTestDriveAppointments(customer.TestDriveAppointments);
            }

            await _customerRepo.DeleteAsync(id);
            await _customerRepo.SaveAsync();
            return true;
        }

        public async Task EditCustomer(ViewCustomerEdit customer)
        {
            _customerRepo.Update(_mapper.Map<DAL.Entities.Customer>(customer));
            await _customerRepo.SaveAsync();
        }

        public async Task<ICollection<ViewCustomer>> GetAllCustomers()
        {
            var customers = await _customerRepo.GetAllCustomers();

            return _mapper.Map<ICollection<ViewCustomer>>(customers);
        }

        public async Task<int> GetTotalCustomers()
        {
            return await _customerRepo.GetTotalCustomers();
        }
    }
}
