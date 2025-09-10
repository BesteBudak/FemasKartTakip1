using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FemasKart.Controllers
{
//    public class SoftwareController : Controller
//    {
//        [Authorize(Roles = "Admin,Arge")]
//        // GET: SoftwareController
//        public ActionResult Index()
//        {
//            return View();
//        }

//        // GET: SoftwareController/Details/5
//        public ActionResult Details(int id)
//        {
//            return View();
//        }

//        // GET: SoftwareController/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: SoftwareController/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: SoftwareController/Edit/5
//        public ActionResult Edit(int id)
//        {
//            return View();
//        }

//        // POST: SoftwareController/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(int id, IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: SoftwareController/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return View();
//        }

//        // POST: SoftwareController/Delete/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Delete(int id, IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }
//    }
public class SoftwareController : BaseController
{
    public IActionResult Index()
    {
        var redirect = RequireLogin();
        if (redirect != null) return redirect;

        return View();
    }

    public IActionResult KartDuzenle()
    {
        var redirect = RequireLogin();
        if (redirect != null) return redirect;

        if (CurrentRole == "Kalite") // Kalite kart düzenleyemez
            return Forbid();

        return View();
    }

    public IActionResult YazilimDuzenle()
    {
        var redirect = RequireLogin();
        if (redirect != null) return redirect;

        if (CurrentRole == "Kalite") // Kalite yazılım düzenleyemez
            return Forbid();

        return View();
    }
}
}
