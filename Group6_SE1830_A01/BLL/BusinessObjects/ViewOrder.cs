using DAL.Entities;

namespace BLL.BusinessObjects
{
    public class ViewOrder
    {
        public int OrderId { get; set; }

        public string CustomerName { get; set; } = null!;

        public string StaffName { get; set; } = null!;

        public DateTime? OrderDate { get; set; }

        public string? Status { get; set; }

        public decimal TotalAmount { get; set; }    

        public virtual ICollection<ViewOrderDetail> ViewOrderDetails { get; set; } = new List<ViewOrderDetail>();
    }
}
