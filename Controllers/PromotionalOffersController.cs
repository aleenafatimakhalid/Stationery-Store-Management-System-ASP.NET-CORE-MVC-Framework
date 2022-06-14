using KMAstationeryStore.Data;
using KMAstationeryStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace KMAstationeryStore.Controllers
{
    public class PromotionalOffersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PromotionalOffersController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {

            IEnumerable<PromotionalOffers> objPromotionalOffersList = _db.Promotional_Offers;
            return View(objPromotionalOffersList);
        }

        public IActionResult ViewPM()
        {

            IEnumerable<PromotionalOffers> objPromotionalOffersList = _db.Promotional_Offers;
            return View(objPromotionalOffersList);
        }

        public IActionResult WishList()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        //INSERT INTO Promotional_Offers (fields) VALUES ("", ...)
        public IActionResult Add(PromotionalOffers obj)
        {
            if (obj.offerName == obj.offerDescription)
            {
                ModelState.AddModelError("offerName", "The offer name caanot exactly match the description.");
            }
            if (ModelState.IsValid)
            {
                _db.Promotional_Offers.Add(obj);
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

            var itemFromDB = _db.Promotional_Offers.Find(id);
            if (itemFromDB == null)
            {
                return NotFound();
            }

            return View(itemFromDB);
        }

        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]

        //delete from Promotional_Offers where...
        public IActionResult RemovePOST(int? id)
        {

            var obj = _db.Promotional_Offers.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Promotional_Offers.Remove(obj);
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

            var itemFromDB = _db.Promotional_Offers.Find(id);
            if (itemFromDB == null)
            {
                return NotFound();
            }

            return View(itemFromDB);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        //update Promotional_Offers set column = value... where
        public IActionResult Update(PromotionalOffers obj)
        {


            if (obj.offerName == obj.offerDescription)
            {
                ModelState.AddModelError("offerName", "The offer name caanot exactly match the description.");
            }
            if (ModelState.IsValid)
            {
                _db.Promotional_Offers.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Item updated successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);


        }
    }
}
