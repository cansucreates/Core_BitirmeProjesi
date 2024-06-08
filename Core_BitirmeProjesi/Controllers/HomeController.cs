using Core_BitirmeProjesi.Data;
using Core_BitirmeProjesi.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Core_BitirmeProjesi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // kullanıcı giriş işlemleri
        public IActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Giris(User user, string ReturnUrl)
        {
            var login = _context.Users.Where(x => x.Username == user.Username && x.Password == user.Password).FirstOrDefault();

            if (login != null)
            {
                var talep = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.Username.ToString())
                };

                ClaimsIdentity kimlik = new ClaimsIdentity(talep, "Login");
                ClaimsPrincipal kural = new ClaimsPrincipal(kimlik);

                HttpContext.SignInAsync(kural);
                if (!string.IsNullOrEmpty(ReturnUrl))
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public IActionResult Cikis()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Giris", "Home");
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
