using BLL.BusinessObjects;
using BLL.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IInventoryService _inventoryService;
        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;

        public HomeController(ILogger<HomeController> logger, IInventoryService inventoryService, ICustomerService customerService, IOrderService orderService)
        {
            _logger = logger;
            _inventoryService = inventoryService;
            _customerService = customerService;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("StaffId") == null)
            {
                return RedirectToAction("Login", "Staff");
            }

            var totalInventory = await _inventoryService.GetTotalInventory();
            var totalCustomers = await _customerService.GetTotalCustomers();    
            var totalRevenue = await _orderService.GetRevenue();    

            var viewHome = new ViewHome
            {
                TotalInventory = totalInventory,
                TotalCustomers = totalCustomers,
                TotalRevenue = totalRevenue
            };  

            return View(viewHome);
        }

        public IActionResult Privacy()
        {
            if (HttpContext.Session.GetInt32("StaffId") == null)
            {
                return RedirectToAction("Login", "Staff");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            if (HttpContext.Session.GetInt32("StaffId") == null)
            {
                return RedirectToAction("Login", "Staff");
            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
