using AutoMapper;
using BLL.BusinessObjects;
using BLL.IServices;
using DAL.Entities;
using DAL.IRepository;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TestDriveAppointmentService : ITestDriveAppointmentService
    {
        private readonly IMapper _mapper;
        private readonly ITestDriveAppointmentRepo _testDriveAppointmentRepo;
        private readonly ICustomerRepo _customerRepo;
        private readonly IInventoryRepo _inventoryRepo;

        public TestDriveAppointmentService(IMapper mapper, ITestDriveAppointmentRepo testDriveAppointmentRepo, ICustomerRepo customerRepo, IInventoryRepo inventoryRepo)
        {
            _mapper = mapper;
            _testDriveAppointmentRepo = testDriveAppointmentRepo;
            _customerRepo = customerRepo;
            _inventoryRepo = inventoryRepo;
        }

        public async Task CreateTestDriveAppointment(CreateTestDriveAppointment createTestDriveAppointment)
        {
            var appointment = _mapper.Map<TestDriveAppointment>(createTestDriveAppointment);

            await _testDriveAppointmentRepo.AddAsync(appointment);
            await _testDriveAppointmentRepo.SaveAsync();
        }

        public async Task<ICollection<ViewTestDriveAppointment>> GetAllAppointments()
        {
            var appointments = await _testDriveAppointmentRepo.GetAllApointments();
            return _mapper.Map<ICollection<ViewTestDriveAppointment>>(appointments);
        }

        public async Task<ViewCreateTestDriveAppointment> GetViewCreateTestDriveAppointment()
        {
            var customers = await _customerRepo.GetAllAsync();
            var inventory = await _inventoryRepo.GetInventory();

            var viewCreateTestDriveAppointment = new ViewCreateTestDriveAppointment
            {
                Customers = customers.ToList(),
                Inventory = inventory.ToList()
            };

            return viewCreateTestDriveAppointment;
        }
    }
}
