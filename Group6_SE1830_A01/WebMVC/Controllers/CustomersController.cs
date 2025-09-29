using BLL.BusinessObjects;
using BLL.IServices;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebMVC.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _customerService.GetAllCustomers();

            return View(customers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ViewCustomerCreate model)
        {
            if (ModelState.IsValid)
            {
                await _customerService.CreateCustomer(model);

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ViewCustomerEdit model)
        {
            if (ModelState.IsValid)
            {
                await _customerService.EditCustomer(model);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _customerService.DeleteCustomer(id);

            if (!result)
            {
                TempData["ErrorMessage"] = "❌ Không thể xóa khách hàng";
                return RedirectToAction(nameof(Index));
            }

            TempData["SuccessMessage"] = "✅ Xóa khách hàng thành công";
            return RedirectToAction(nameof(Index));
        }
    }
}
