namespace BLL.BusinessObjects
{
    public class CreateOrderDetail
    {
        public int VersionId { get; set; }
        public int ColorId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
