using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class TestDriveAppointmentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
