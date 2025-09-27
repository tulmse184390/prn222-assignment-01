using AutoMapper;
using BLL.BusinessObjects;
using BLL.IServices;
using DAL.Entities;
using DAL.IRepository;

namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepo _orderRepo;
        private readonly IStaffRepo _staffRepo;
        private readonly ICustomerRepo _customerRepo;
        private readonly IInventoryRepo _inventoryRepo;

        public OrderService(IMapper mapper, IOrderRepo orderRepo, IStaffRepo staffRepo, ICustomerRepo customerRepo, IInventoryRepo inventoryRepo)
        {
            _mapper = mapper;
            _orderRepo = orderRepo;
            _staffRepo = staffRepo;
            _customerRepo = customerRepo;
            _inventoryRepo = inventoryRepo;
        }

        public async Task ChangeOrderStatus(ChangeOrderStatus changeOrderStatus)
        {
            var order = await _orderRepo.GetByIdAsync(changeOrderStatus.OrderId);

            if (order == null)
            {
                throw new Exception("Order not found");
            }

            order.Status = changeOrderStatus.Status;
            _orderRepo.Update(order);
            await _orderRepo.SaveAsync();
        }

        public async Task<ICollection<ViewOrder>> GetAllOrders()
        {
            var orders = await _orderRepo.GetAllOrders();

            return _mapper.Map<ICollection<ViewOrder>>(orders);
        }

        public async Task<ViewCreateOrder> GetInfoForCreateOrder()
        {
            var customers = await _customerRepo.GetAllAsync();
            var staffs = await _staffRepo.GetAllAsync();
            var inventories = await _inventoryRepo.GetInventory();

            if (customers == null || staffs == null || inventories == null)
            {
                throw new Exception("Data not found");
            }

            var viewCreateOrder = new ViewCreateOrder
            {
                Customers = customers.ToList(),
                Staffs = staffs.ToList(),
                Inventories = inventories
            };

            return viewCreateOrder;
        }
    }
}
