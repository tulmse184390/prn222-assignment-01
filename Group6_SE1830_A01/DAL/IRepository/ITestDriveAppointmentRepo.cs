using DAL.Entities;

namespace DAL.IRepository
{
    public interface ITestDriveAppointmentRepo : IRepository<TestDriveAppointment>
    {
        Task<ICollection<TestDriveAppointment>> GetAllApointments();
        Task DeleteTestDriveAppointments(ICollection<TestDriveAppointment> testDriveAppointments);
        Task<ICollection<TestDriveAppointment>> GetAppointmentsInDay(DateTime date);
        Task<ICollection<TestDriveAppointment>> GetScheduledAppointmentsInDay(DateTime date);
    }
}
