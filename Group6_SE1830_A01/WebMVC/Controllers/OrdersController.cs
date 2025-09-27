using BLL.BusinessObjects;
using BLL.IServices;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebMVC.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var viewOrders = await _orderService.GetAllOrders();

            return View(viewOrders);
        }

        public async Task<IActionResult> Create()
        {
            var viewCreateOrder = await _orderService.GetInfoForCreateOrder();

            return View(viewCreateOrder);
        }

        public async Task<IActionResult> Confirm(int id)
        {
            var viewConfirmOrder = await _orderService.GetOrderById(id);

            return View(viewConfirmOrder);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatus(ChangeOrderStatus model)
        {
            try
            {
                await _orderService.ChangeOrderStatus(model);
                return RedirectToAction("Confirm", new { id = model.OrderId });
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrder createOrder)
        {
            if (createOrder == null || createOrder.CreateOrderDetails == null || !createOrder.CreateOrderDetails.Any())
            {
                ModelState.AddModelError("", "Đơn hàng không hợp lệ. Vui lòng chọn ít nhất 1 xe.");
                var viewCreateOrder = await _orderService.GetInfoForCreateOrder();
                return View("Create", viewCreateOrder);
            }

            var orderId = await _orderService.CreateOrder(createOrder);

            return RedirectToAction("Confirm", new { id = orderId });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderService.DeleteOrder(id); 
            return RedirectToAction("Index");
        }
    }
}
