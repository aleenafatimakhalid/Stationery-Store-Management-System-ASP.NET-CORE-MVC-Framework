using System.Collections.Generic;
using KMAstationeryStore.Data;
using KMAstationeryStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace KMAstationeryStore.Controllers
{
    public class ProductItemsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductItemsController(ApplicationDbContext db)
        {
            _db = db;
        }

        //select * from Product_Items
        public IActionResult Index()
        {


            IEnumerable<ProductItem> objProductItemsList = _db.Product_Items;
            return View(objProductItemsList);
        }

        //select * from Product_Items
        public IActionResult Browse()
        {

            IEnumerable<ProductItem> objProductItemsList = _db.Product_Items;
            return View(objProductItemsList);
        }


        

        public IActionResult Add()
        {
            return View();
        }



        //INSERT INTO Product_Items (fields) VALUES ("", ...)
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Add(ProductItem obj)
        {
            if (obj.itemTitle == obj.category)
            {
                ModelState.AddModelError("itemTitle", "The Product Item title cannot exactly match the category.");
            }
            if (ModelState.IsValid)
            {
                _db.Product_Items.Add(obj);
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

            var itemFromDB = _db.Product_Items.Find(id);
            if (itemFromDB == null)
            {
                return NotFound();
            }

            return View(itemFromDB);
        }

        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]

        //delete from Product_Items where...
        public IActionResult RemovePOST(int? id)
        {

            var obj = _db.Product_Items.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            
                _db.Product_Items.Remove(obj);
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

            var itemFromDB = _db.Product_Items.Find(id);
            if (itemFromDB == null)
            {
                return NotFound();
            }

            return View(itemFromDB);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        //update Product_Items set column = value... where
        public IActionResult Update(ProductItem obj)
        {


            if (obj.itemTitle == obj.category)
            {
                ModelState.AddModelError("itemTitle", "The Product Item title cannot exactly match the category.");
            }
            if (ModelState.IsValid)
            {
                _db.Product_Items.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Item updated successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
           

        }
    }
}
