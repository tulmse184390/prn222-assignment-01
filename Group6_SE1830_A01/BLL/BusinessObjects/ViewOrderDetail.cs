using DAL.Entities;

namespace BLL.BusinessObjects
{
    public class ViewOrderDetail
    {
        public string VersionName { get; set; } = null!;

        public string ModelName { get; set; } = null!;

        public string? ColorName { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal? Discount { get; set; }

        public decimal FinalPrice { get; set; }
    }
}
