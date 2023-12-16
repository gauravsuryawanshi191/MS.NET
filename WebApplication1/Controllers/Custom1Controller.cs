using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class Custom1Controller : Controller
    {
        public IActionResult MyPage()
        {
            return View();
            //return Content("<script>alert('Welcome To All');</script>");

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
