using Core_BitirmeProjesi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Core_BitirmeProjesi.Models;

namespace Core_BitirmeProjesi.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BooksController(ApplicationDbContext db)
        {
            _db = db; 
        }

        public IActionResult Index()
        {
            return View(_db.Books.ToList());
        }

        //Kaydetme işlemi 
        public IActionResult Create()
        {
            List<SelectListItem> authorid_liste = (from x in _db.Authors
                                                select new SelectListItem
                                                {
                                                    Value = x.AuthorID.ToString(),
                                                    Text = x.Name
                                                }).ToList();
            ViewBag.AuthorID = authorid_liste;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book books)
        {
            _db.Books.Add(books);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Güncelleme işlemi
        public IActionResult Edit(int id)
        {
            List<SelectListItem> authorid_liste = (from x in _db.Authors
                                                select new SelectListItem
                                                {
                                                    Value = x.AuthorID.ToString(),
                                                    Text = x.Name
                                                }).ToList();
            ViewBag.AuthorID = authorid_liste;
            return View(_db.Books.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(int id, Book books)
        {
            _db.Books.Update(books);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Silme işlemi (direk butonla silinecek)
        public IActionResult Delete(int id)
        {
            var sil = _db.Books.Find(id);
            _db.Books.Remove(sil);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
   