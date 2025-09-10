using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FemasKart.Controllers
{
    //public class OnaySurecleriController : Controller
    //{

    //    // GET: OnaySurecleriController
    //    public ActionResult Index()
    //    {
    //        return View();
    //    }

    //    // GET: OnaySurecleriController/Details/5
    //    public ActionResult Details(int id)
    //    {
    //        return View();
    //    }

    //    // GET: OnaySurecleriController/Create
    //    public ActionResult Create()
    //    {
    //        return View();
    //    }

    //    // POST: OnaySurecleriController/Create
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

    //    // GET: OnaySurecleriController/Edit/5
    //    public ActionResult Edit(int id)
    //    {
    //        return View();
    //    }

    //    // POST: OnaySurecleriController/Edit/5
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

    //    // GET: OnaySurecleriController/Delete/5
    //    public ActionResult Delete(int id)
    //    {
    //        return View();
    //    }

    //    // POST: OnaySurecleriController/Delete/5
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

    public class OnaySurecleriController : BaseController
    {

        public IActionResult Index()
        {
            var redirect = RequireLogin();
            if (redirect != null) return redirect;

            if (CurrentRole != "Admin" && CurrentRole != "Kalite")
                return Forbid(); // sadece Admin ve Kalite erişebilir

            return View();
        }


    }

}