 namespace BLL.BusinessObjects
{
    public class CreateTestDriveAppointment
    {
        public int CustomerId { get; set; }
        public int CarVersionId { get; set; }
        public int ColorId { get; set; }
        public DateTime DateTime { get; set; }
        public string Status { get; set; } = "Scheduled";
        public string? Feedback { get; set; }
    }
}
