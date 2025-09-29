using BLL.BusinessObjects;
using BLL.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        [HttpPost]
        public async Task<IActionResult> UpdateAllQuantities(List<UpdateInventoryQuantity> updates)
        {
            if (updates == null || !updates.Any())
            {
                return BadRequest("No updates provided.");
            }
            await _inventoryService.UpdateAllQuantities(updates);
            return RedirectToAction("Index");
        }
    }
}
