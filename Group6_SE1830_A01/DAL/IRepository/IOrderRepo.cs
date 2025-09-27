using DAL.Entities;

namespace DAL.IRepository
{
    public interface IOrderRepo : IRepository<Order>
    {
        Task<ICollection<Order>> GetAllOrders();
    }
}
