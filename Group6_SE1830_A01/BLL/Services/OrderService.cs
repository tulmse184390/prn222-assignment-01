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

        public async Task<int> CreateOrder(CreateOrder createOrder)
        {
            var order = new Order
            {
                CustomerId = createOrder.CustomerId,
                StaffId = createOrder.StaffId,
                OrderDate = DateTime.Now,
                Status = "Pending",
            };

            foreach (var item in createOrder.CreateOrderDetails)
            {
                order.OrderDetails.Add(new OrderDetail
                {
                    VersionId = item.VersionId,
                    ColorId = item.ColorId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    FinalPrice = item.Quantity * item.UnitPrice
                });
            }

            return (await _orderRepo.AddAsync(order)).OrderId;
        }

        public async Task DeleteOrder(int id)
        {
            await _orderRepo.DeleteOrder(id);
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

        public async Task<ViewConfirmOrder?> GetOrderById(int id)
        {
            var order = await _orderRepo.GetOrderById(id);

            var viewConfirmOrder = _mapper.Map<ViewConfirmOrder>(order);

            return viewConfirmOrder;
        }
    }
}
