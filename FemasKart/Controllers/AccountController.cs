using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace FemasKart.Controllers
{
    //public class AccountController : Controller
    //{
    //    // GET: AccountController
    //    public ActionResult Login()
    //    {
    //        return View();
    //    }
    //    public ActionResult Register()
    //    {
    //        return View();
    //    }

    //    // GET: AccountController/Details/5
    //    public ActionResult Details(int id)
    //    {
    //        return View();
    //    }

    //    // GET: AccountController/Create
    //    public ActionResult Create()
    //    {
    //        return View();
    //    }

    //    // POST: AccountController/Create
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

    //    // GET: AccountController/Edit/5
    //    public ActionResult Edit(int id)
    //    {
    //        return View();
    //    }

    //    // POST: AccountController/Edit/5
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

    //    // GET: AccountController/Delete/5
    //    public ActionResult Delete(int id)
    //    {
    //        return View();
    //    }

    //    // POST: AccountController/Delete/5
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

    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
        
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(); // Register.cshtml dosyasını açar
        }

        [HttpPost]
        //public IActionResult Register(RegisterViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Kullanıcı kaydetme işlemleri burada olacak
        //        // Örnek: veritabanına ekleme, password hash vs.

        //        // Kayıt başarılıysa login sayfasına yönlendir
        //        return RedirectToAction("Login", "Account");
        //    }

        //    // Model hatalıysa tekrar register sayfasını göster
        //    return View(model);
        //}

        [HttpPost]
            public IActionResult Login(string email, string password)
            {
                // Basit örnek kullanıcı listesi
                var users = new List<(string Email, string Password, string Role)>
        {
            ("admin@ferre.com", "123", "Admin"),
            ("arge@ferre.com", "123", "Arge"),
            ("kalite@ferre.com", "123", "Kalite")
        };

                var user = users.FirstOrDefault(u => u.Email == email && u.Password == password);

                if (user.Email == null)
                {
                    ViewBag.Error = "Email veya şifre yanlış!";
                    return View();
                }

                // Session oluştur
                HttpContext.Session.SetString("User", user.Email);
                HttpContext.Session.SetString("Role", user.Role);

                return RedirectToAction("Index", "Home");
            }

            public IActionResult Logout()
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login");
            }
        }


    }



