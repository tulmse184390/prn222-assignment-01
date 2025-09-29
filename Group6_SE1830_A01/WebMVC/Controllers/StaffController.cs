using BLL.BusinessObjects;
using BLL.IServices;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class StaffController : Controller
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        public async Task<IActionResult> Login(LoginStaff loginStaff)
        {
            if (loginStaff == null || loginStaff.Email == null)
            {
                return View();
            }

            var staffInfo = await _staffService.Login(loginStaff);

            if (staffInfo == null)
            {
                ViewBag.Error = "Email hoặc mật khẩu không đúng.";
                return View();
            }

            HttpContext.Session.SetInt32("StaffId", staffInfo.StaffId);
            HttpContext.Session.SetString("StaffName", staffInfo.FullName);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}