using BLL.BusinessObjects;
using DAL.Entities;

namespace BLL.IServices
{
    public interface IOrderService
    {
        Task<ICollection<ViewOrder>> GetAllOrders();
        Task ChangeOrderStatus(ChangeOrderStatus changeOrderStatus);
        Task<ViewCreateOrder> GetInfoForCreateOrder();
        Task<int> CreateOrder(CreateOrder createOrder);
        Task<ViewConfirmOrder?> GetOrderById(int id);
        Task DeleteOrder(int id);
        Task<decimal> GetRevenue();
    }
}
