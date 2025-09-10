using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FemasKart.Controllers
{
    //public class CardController : Controller
    //{

    //    // GET: CardController
    //    public ActionResult Index()
    //    {
    //        return View();
    //    }

    //    // GET: CardController/Details/5
    //    public ActionResult Details(int id)
    //    {
    //        return View();
    //    }

    //    // GET: CardController/Create
    //    public ActionResult Create()
    //    {
    //        return View();
    //    }

    //    // POST: CardController/Create
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Create(IFormCollection collection)
    //    {
    //        try
    //        {
    //            return RedirectToAction(nameof(Index));
    //        }
    //        catch
    //        {
    //            return View();
    //        }
    //    }

    //    // GET: CardController/Edit/5
    //    public ActionResult Edit(int id)
    //    {
    //        return View();
    //    }

    //    // POST: CardController/Edit/5
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Edit(int id, IFormCollection collection)
    //    {
    //        try
    //        {
    //            return RedirectToAction(nameof(Index));
    //        }
    //        catch
    //        {
    //            return View();
    //        }
    //    }

    //    // GET: CardController/Delete/5
    //    public ActionResult Delete(int id)
    //    {
    //        return View();
    //    }

    //    // POST: CardController/Delete/5
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Delete(int id, IFormCollection collection)
    //    {
    //        try
    //        {
    //            return RedirectToAction(nameof(Index));
    //        }
    //        catch
    //        {
    //            return View();
    //        }
    //    }
    //}
    public class CardController : BaseController
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
