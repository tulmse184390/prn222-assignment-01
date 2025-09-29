using BLL.BusinessObjects;
using BLL.IServices;
using Microsoft.AspNetCore.Mvc;

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
            if (HttpContext.Session.GetInt32("StaffId") == null)
            {
                return RedirectToAction("Login", "Staff");
            }

            var viewOrders = await _orderService.GetAllOrders();

            return View(viewOrders);
        }

        public async Task<IActionResult> Create()
        {
            if (HttpContext.Session.GetInt32("StaffId") == null)
            {
                return RedirectToAction("Login", "Staff");
            }

            var viewCreateOrder = await _orderService.GetInfoForCreateOrder();

            return View(viewCreateOrder);
        }

        public async Task<IActionResult> Confirm(int id)
        {
            if (HttpContext.Session.GetInt32("StaffId") == null)
            {
                return RedirectToAction("Login", "Staff");
            }

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
            if (HttpContext.Session.GetInt32("StaffId") == null)
            {
                return RedirectToAction("Login", "Staff");
            }

            if (createOrder == null || createOrder.CreateOrderDetails == null || !createOrder.CreateOrderDetails.Any())
            {
                var viewCreateOrder = await _orderService.GetInfoForCreateOrder();
                return View("Create", viewCreateOrder);
            }

            var orderId = await _orderService.CreateOrder(createOrder);

            return RedirectToAction("Confirm", new { id = orderId });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (HttpContext.Session.GetInt32("StaffId") == null)
            {
                return RedirectToAction("Login", "Staff");
            }

            await _orderService.DeleteOrder(id); 
            return RedirectToAction("Index");
        }
    }
}
