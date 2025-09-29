using BLL.BusinessObjects;

namespace BLL.IServices
{
    public interface ITestDriveAppointmentService
    {
        Task<ICollection<ViewTestDriveAppointment>> GetAllAppointments();
        Task<ViewCreateTestDriveAppointment> GetViewCreateTestDriveAppointment();
        Task CreateTestDriveAppointment(CreateTestDriveAppointment createTestDriveAppointment);
        Task CheckAppointmentStatus();
        Task DeleteAppointment(int id);
        Task StartAppointment(int id);
        Task CompleteAppointment(int id);
    }
}
