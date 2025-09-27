using DAL.Entities;

namespace BLL.BusinessObjects
{
    public class ViewCreateOrder
    {
        public ICollection<Customer> Customers { get; set; } = new List<Customer>();    

        public ICollection<Staff> Staffs { get; set; } = new List<Staff>();

        public ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();        
    }
}
