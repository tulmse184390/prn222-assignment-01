namespace BLL.BusinessObjects
{
    public class ViewConfirmOrder
    {
        public int OrderId { get; set; }

        public string CustomerName { get; set; } = null!;

        public string StaffName { get; set; } = null!;

        public DateTime? OrderDate { get; set; }

        public string? Status { get; set; }

        public ICollection<ViewOrderDetail> ViewOrderDetails { get; set; } = new List<ViewOrderDetail>();  

        public decimal TotalAmount { get; set; }
    }
}
