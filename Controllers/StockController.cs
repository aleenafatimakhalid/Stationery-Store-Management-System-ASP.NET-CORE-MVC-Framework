using KMAstationeryStore.Data;
using KMAstationeryStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace KMAstationeryStore.Controllers
{
    public class StockController : Controller
    {
        private readonly ApplicationDbContext _db;

        public StockController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {

            IEnumerable<Stock> objStock = _db.stock;
            return View(objStock);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        //INSERT INTO stock (fields) VALUES ("", ...)
        public IActionResult Add(Stock obj)
        {
            
            if (ModelState.IsValid)
            {
                _db.stock.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Item added successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);


        }

        public IActionResult Remove(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var itemFromDB = _db.stock.Find(id);
            if (itemFromDB == null)
            {
                return NotFound();
            }

            return View(itemFromDB);
        }

        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]


        //delete from stock where...
        public IActionResult RemovePOST(int? id)
        {

            var obj = _db.stock.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.stock.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Item removed successfully!";
            return RedirectToAction("Index");



        }

        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var itemFromDB = _db.stock.Find(id);
            if (itemFromDB == null)
            {
                return NotFound();
            }

            return View(itemFromDB);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        //update stock set column = value... where
        public IActionResult Update(Stock obj)
        {


          
            if (ModelState.IsValid)
            {
                _db.stock.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Item updated successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);


        }
    }
}
