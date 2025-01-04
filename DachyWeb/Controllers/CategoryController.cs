using DachyWeb.Data;
using DachyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace DachyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (int.TryParse(obj.Name, out _))
            {
                ModelState.AddModelError("Name", "Nazwa kategorii nie może być liczbą.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Kategoria została dodana do listy";
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        public IActionResult Edit(int? categoryId)
        {
            if (categoryId == null || categoryId == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Categories.Find(categoryId);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (int.TryParse(obj.Name, out _))
            {
                ModelState.AddModelError("Name", "Nazwa kategorii nie może być liczbą.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Kategoria została edytowana";
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Delete(int? categoryId)
        {
            if (categoryId == null || categoryId == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Categories.Find(categoryId);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? categoryId)
        {
            Category? obj = _db.Categories.Find(categoryId);

            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Kategoria została usunięta z listy";
            return RedirectToAction("Index");
        }
    }
}
