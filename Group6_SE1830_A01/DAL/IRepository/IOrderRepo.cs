using DAL.Entities;

namespace DAL.IRepository
{
    public interface IOrderRepo : IRepository<Order>
    {
        Task<ICollection<Order>> GetAllOrders();
        Task<Order?> GetOrderById(int id);
        Task DeleteOrder(int id);
        Task<decimal> GetRevenue();
        Task<ICollection<Order>> GetPendingOrder();
    }
}
