using Core1.Data;
using Core1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core1.Controllers
{
    public class ItemsController : Controller
    {
        private readonly AppDbContext _db;

        public ItemsController(AppDbContext _db)
        {
            this._db = _db;
            // 01206845285
            // rahmabarakat@icolud.com
            // rahma barakat532020$$##
        }

        public IActionResult Index()
        {
            IEnumerable<Item> items = _db.items.ToList();
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item item)
        {
            if(!ModelState.IsValid)
            {
                return View(item);
            }
            _db.items.Add(item);
            _db.SaveChanges();

            TempData["Success"] = "Item Created Successfully";
            return RedirectToAction("Index");
        }

        //Get
        public IActionResult Edit(int? ProductId)
        {
            if (ProductId == null || ProductId == 0)
            {
                return NotFound();
            }
            var item = _db.items.Find(ProductId);

            return View(item);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Item item)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            _db.items.Update(item);
            _db.SaveChanges();
            TempData["Success"] = "Item Updated Successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int itemId)
        {
            var item = _db.items.First(id => id.ProductId == itemId);
            _db.Remove(item);
            _db.SaveChanges();
            TempData["successData"] = "Item has been deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
