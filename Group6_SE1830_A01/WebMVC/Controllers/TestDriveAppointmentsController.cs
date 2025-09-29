using BLL.BusinessObjects;
using BLL.IServices;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class TestDriveAppointmentsController : Controller
    {
        private readonly ITestDriveAppointmentService _testDriveAppointmentService;

        public TestDriveAppointmentsController(ITestDriveAppointmentService testDriveAppointmentService)
        {
            _testDriveAppointmentService = testDriveAppointmentService;
        }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("StaffId") == null)
            {
                return RedirectToAction("Login", "Staff");
            }

            var viewAppointments = await _testDriveAppointmentService.GetAllAppointments();

            return View(viewAppointments);
        }

        public async Task<IActionResult> Create()
        {
            if (HttpContext.Session.GetInt32("StaffId") == null)
            {
                return RedirectToAction("Login", "Staff");
            }

            var viewCreateAppointment = await _testDriveAppointmentService.GetViewCreateTestDriveAppointment();
            return View(viewCreateAppointment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ViewCreateTestDriveAppointment model)
        {
            if (HttpContext.Session.GetInt32("StaffId") == null)
            {
                return RedirectToAction("Login", "Staff");
            }

            if (!ModelState.IsValid)
            {
                var viewCreateAppointment = await _testDriveAppointmentService.GetViewCreateTestDriveAppointment();
                model.Customers = viewCreateAppointment.Customers;
                model.Inventory = viewCreateAppointment.Inventory;
                return View(model);
            }

            try
            {
                await _testDriveAppointmentService.CreateTestDriveAppointment(model.CreateTestDriveAppointment);
                return RedirectToAction("Index");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message); // lỗi business logic
                var viewCreateAppointment = await _testDriveAppointmentService.GetViewCreateTestDriveAppointment();
                model.Customers = viewCreateAppointment.Customers;
                model.Inventory = viewCreateAppointment.Inventory;
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (HttpContext.Session.GetInt32("StaffId") == null)
            {
                return RedirectToAction("Login", "Staff");
            }

            await _testDriveAppointmentService.DeleteAppointment(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Start(int id)
        {
            if (HttpContext.Session.GetInt32("StaffId") == null)
            {
                return RedirectToAction("Login", "Staff");
            }

            await _testDriveAppointmentService.StartAppointment(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Complete(int id)
        {
            if (HttpContext.Session.GetInt32("StaffId") == null)
            {
                return RedirectToAction("Login", "Staff");
            }

            await _testDriveAppointmentService.CompleteAppointment(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GetAppointments()
        {
            var viewAppointments = await _testDriveAppointmentService.GetAllAppointments();
            return Json(viewAppointments);
        }
    }
}

