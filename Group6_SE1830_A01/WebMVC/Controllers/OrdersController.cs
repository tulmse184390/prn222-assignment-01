using BLL.BusinessObjects;
using BLL.IServices;
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

        public IActionResult Confirm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatus(ChangeOrderStatus model)
        {
            try
            {
                await _orderService.ChangeOrderStatus(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
