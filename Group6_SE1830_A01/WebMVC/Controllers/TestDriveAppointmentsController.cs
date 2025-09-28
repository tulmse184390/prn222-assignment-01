using BLL.BusinessObjects;
using BLL.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
            var viewAppointments = await _testDriveAppointmentService.GetAllAppointments();

            return View(viewAppointments);
        }

        public async Task<IActionResult> Create()
        {
            var viewCreateAppointment = await _testDriveAppointmentService.GetViewCreateTestDriveAppointment();
            return View(viewCreateAppointment);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTestDriveAppointment model)
        {
            if (model.CarVersionId == 0 || model.ColorId == 0)
            {
                ModelState.AddModelError("", "Vui lòng chọn xe.");
                return View(model);
            }

            if (model.DateTime == default(DateTime))
            {
                ModelState.AddModelError("", "Vui lòng chọn ngày giờ.");
                return View(model);
            }

            await _testDriveAppointmentService.CreateTestDriveAppointment(model);
            return RedirectToAction("Index");
        }
    }
}
