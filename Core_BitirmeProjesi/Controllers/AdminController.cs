using Core_BitirmeProjesi.Data;
using Core_BitirmeProjesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core_BitirmeProjesi.Controllers
{
    public class AdminController : Controller
    {
        // dependency injection
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Giris(User user)
        {
            var login = from x in _context.Users
                        where x.Username == user.Username && x.Password == user.Password
                        select x;
            if (login.Count() > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = "Kullanıcı adı veya şifre hatalı!";
                return View();
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        // kullanıcı kayıt
        public IActionResult Kayit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Kayit(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Kayıt başarılı! Giriş yapabilirsiniz.";
                return RedirectToAction("Giris");
            }
            return View(user);
        }
    }
}
