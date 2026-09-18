using LoginWithSession.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoginWithSession.Controllers
{
    public class SampleController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel m)
        {
            if(m.UserName=="sneha" && m.Password=="1234")
            {
                HttpContext.Session.SetString("user_name", m.UserName);
                //ViewBag.msg = "Login Successfully";
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.msg = "Invalid user name or password";
                return View();

            }
        }

        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("user_name") == null)
            {
                return RedirectToAction("Login");

            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
