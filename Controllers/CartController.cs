using Microsoft.AspNetCore.Mvc;
using KMAstationeryStore.Data;
using KMAstationeryStore.Models;


namespace KMAstationeryStore.Controllers
{
    public class CartController : Controller
    {

        private readonly ApplicationDbContext _db;

        public CartController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Cart> objCartList = _db.cart;
            return View(objCartList);
            
        }

        public IActionResult Add(int? id)
        {
            var itemFromDB = _db.Product_Items.Find(id);
            if (itemFromDB == null)
            {
                return NotFound();
            }

            return View(itemFromDB);
           
        }

        [HttpPost, ActionName("Add")]
        [ValidateAntiForgeryToken]

 
        public IActionResult AddPOST(int? id)
        {
            var obj = _db.Product_Items.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            Cart entry;
            entry = new Cart();
           // entry.itemId = obj.itemId;
            entry.itemTitle = obj.itemTitle;
            entry.description = obj.description;
            entry.category = obj.category;
            entry.price = obj.price;
            entry.quantity = "1";

            if (ModelState.IsValid)
            {
                _db.cart.Add(entry);
                _db.SaveChanges();
                TempData["success"] = "Item added successfully to cart!";
                return RedirectToAction("Index");
            }
            return View(obj);


        }

        public IActionResult Remove(int? id)
        {
            var itemFromDB = _db.cart.Find(id);
            if (itemFromDB == null)
            {
                return NotFound();
            }

            return View(itemFromDB);

        }

        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]


        public IActionResult RemovePOST(int? id)
        {
            var obj = _db.cart.Find(id);
          
            if (obj == null)
            {
                return NotFound();
            }

                _db.cart.Remove(obj);
                _db.SaveChanges();
                TempData["success"] = "Item updated successfully from cart!";
                return RedirectToAction("Index"); 

        }
    }
}
