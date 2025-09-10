using Microsoft.AspNetCore.Mvc;

namespace FemasKart.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
