using Core_BitirmeProjesi.Data;
using Core_BitirmeProjesi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core_BitirmeProjesi.Controllers
{
    public class AuthorController : Controller
    {

        private readonly ApplicationDbContext _db;

        public AuthorController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Authors.ToList());
        }

        //Kaydetme işlemi
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            _db.Authors.Add(author);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Güncelleme işlemi
        public IActionResult Edit(int id)
        {
            return View(_db.Authors.Find(id));
          
        }

        [HttpPost]
        public IActionResult Edit(int id, Author author)
        {
            _db.Authors.Update(author);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Silme işlemi
        public IActionResult Delete(int id)
        {
           return View(_db.Authors.Find(id));
        }

        [HttpPost]
        public IActionResult Delete(int id, Author author)
        {
            _db.Authors.Remove(author);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
