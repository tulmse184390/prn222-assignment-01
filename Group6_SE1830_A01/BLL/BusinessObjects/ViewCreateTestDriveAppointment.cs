using DAL.Entities;

namespace BLL.BusinessObjects
{
    public class ViewCreateTestDriveAppointment
    {
        public ICollection<Customer> Customers { get; set; } = new List<Customer>();    
        public ICollection<Inventory> Inventory { get; set; } = new List<Inventory>();
        public CreateTestDriveAppointment CreateTestDriveAppointment { get; set; } = new CreateTestDriveAppointment();
    }
}
