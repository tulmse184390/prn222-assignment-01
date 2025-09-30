using AutoMapper;
using BLL.BusinessObjects;
using BLL.IServices;
using DAL.Entities;
using DAL.IRepository;

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

        public async Task CheckAppointmentStatus()
        {
            var appointments = await _testDriveAppointmentRepo.GetAppointmentsInDay(DateTime.Today);

            foreach (var appointment in appointments)
            {
                if ((DateTime.Now - appointment.DateTime).TotalMinutes > 3 && appointment.Status == "Waiting")
                {
                    appointment.Status = "No Show";
                    _testDriveAppointmentRepo.Update(appointment);
                }
                else if ((DateTime.Now - appointment.DateTime).TotalMinutes > 0 && appointment.Status == "Scheduled")
                {
                    appointment.Status = "Waiting";
                    _testDriveAppointmentRepo.Update(appointment);
                }
                else if ((DateTime.Now - appointment.DateTime).TotalMinutes > 3 && appointment.Status == "Driving")
                {
                    appointment.Status = "Done";
                    _testDriveAppointmentRepo.Update(appointment);
                }
                await _testDriveAppointmentRepo.SaveAsync();
            }
        }

        public async Task CompleteAppointment(int id)
        {
            var appointment = await _testDriveAppointmentRepo.GetByIdAsync(id);
            if (appointment != null && appointment.Status == "Driving")
            {
                appointment.Status = "Done";
                _testDriveAppointmentRepo.Update(appointment);
                await _testDriveAppointmentRepo.SaveAsync();
            }
        }

        public async Task CreateTestDriveAppointment(CreateTestDriveAppointment createTestDriveAppointment)
        {
            var appointmentDate = createTestDriveAppointment.DateTime;
            var today = DateTime.Today;
            var now = DateTime.Now;

            if (appointmentDate.Date < today || appointmentDate.Date > today.AddDays(2))
            {
                throw new InvalidOperationException("Chỉ có thể đặt lịch cho hôm nay, ngày mai hoặc ngày mốt.");
            }

            if (appointmentDate.Date == today)
            {
                if (appointmentDate.Hour < 8 || appointmentDate.Hour >= 20)
                {
                    throw new InvalidOperationException("Chỉ đặt lịch trong khoảng 8h sáng đến 8h tối.");
                }

                if (appointmentDate < now.AddMinutes(1))
                {
                    throw new InvalidOperationException("Thời gian hẹn phải cách hiện tại ít nhất 10 phút.");
                }
            }
            else
            {
                var existingAppointments = await _testDriveAppointmentRepo
                    .GetAppointmentsInDay(appointmentDate.Date);

                if (existingAppointments.Count() >= 4)
                {
                    throw new InvalidOperationException("Mỗi ngày chỉ được đặt tối đa 4 lịch trước.");
                }

                if (appointmentDate.Hour < 8 || appointmentDate.Hour >= 20)
                {
                    throw new InvalidOperationException("Chỉ đặt lịch trong khoảng 8h sáng đến 8h tối.");
                }
            }

            // Mapping và lưu DB
            var appointment = _mapper.Map<TestDriveAppointment>(createTestDriveAppointment);

            await _testDriveAppointmentRepo.AddAsync(appointment);
            await _testDriveAppointmentRepo.SaveAsync();
        }

        public async Task DeleteAppointment(int id)
        {
            await _testDriveAppointmentRepo.DeleteAsync(id);
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

        public async Task StartAppointment(int id)
        {
            var appointment = await _testDriveAppointmentRepo.GetByIdAsync(id);
            if (appointment != null && appointment.Status == "Waiting")
            {
                appointment.Status = "Driving";
                _testDriveAppointmentRepo.Update(appointment);
                await _testDriveAppointmentRepo.SaveAsync();
            }
        }
    }
}
