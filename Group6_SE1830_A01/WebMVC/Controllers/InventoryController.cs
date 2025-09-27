using BLL.IServices;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public async Task<IActionResult> Index()
        {
            var viewInventory = await _inventoryService.GetInventory();

            return View(viewInventory);
        }
    }
}
