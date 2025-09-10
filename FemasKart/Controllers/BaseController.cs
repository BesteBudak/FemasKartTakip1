using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FemasKart.Controllers
{
    public class BaseController : Controller
    {
        protected string? CurrentUser => HttpContext.Session.GetString("User");
        protected string? CurrentRole => HttpContext.Session.GetString("Role");

        protected IActionResult RequireLogin()
        {
            if (string.IsNullOrEmpty(CurrentUser))
                return RedirectToAction("Login", "Account");

            return null;
        }
    }

}
