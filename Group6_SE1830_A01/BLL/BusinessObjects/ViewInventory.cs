using DAL.Entities;

namespace BLL.BusinessObjects
{
    public class ViewInventory
    {
        public int InventoryId { get; set; }    

        public string ModelName { get; set; } = null!;

        public string VersionName { get; set; } = null!;

        public int? RangeKm { get; set; }

        public int? Seat { get; set; }

        public decimal BasePrice { get; set; }

        public string? ColorName { get; set; }

        public int? Quantity { get; set; }
    }
}
