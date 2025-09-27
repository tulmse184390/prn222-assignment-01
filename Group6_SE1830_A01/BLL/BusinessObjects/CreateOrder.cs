namespace BLL.BusinessObjects
{
    public class CreateOrder
    {
        public int CustomerId { get; set; }
        public int StaffId { get; set; }
        public List<CreateOrderDetail> CreateOrderDetails { get; set; } = new();
    }
}
