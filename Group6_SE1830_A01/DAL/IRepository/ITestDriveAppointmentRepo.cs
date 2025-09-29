using DAL.Entities;

namespace DAL.IRepository
{
    public interface ITestDriveAppointmentRepo : IRepository<TestDriveAppointment>
    {
        Task<ICollection<TestDriveAppointment>> GetAllApointments();
        Task DeleteTestDriveAppointments(ICollection<TestDriveAppointment> testDriveAppointments);
    }
}
