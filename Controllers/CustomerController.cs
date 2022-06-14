using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using KMAstationeryStore.Data;
using KMAstationeryStore.Models;



namespace KMAstationeryStore.Controllers
{
    public class CustomerController : Controller
    {

        private readonly ApplicationDbContext _db;

        public CustomerController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult HomePage()
        {
             
            return View();
        }

        public IActionResult Index()
        {

            IEnumerable<Customer> objCustomerList = _db.customer;
            return View(objCustomerList);
        }

        public IActionResult CheckOutHomePage()
        {
            //take input from user his id for confirmation wahan sa call checkout confirmed 
            IEnumerable<Customer> objCustomerList = _db.customer;
            return View(objCustomerList);
            
        }


        public IActionResult CheckOut(int? id)
        {
            var itemFromDB = _db.customer.Find(id);
            if (itemFromDB == null)
            {
                return NotFound();
            }

            return View(itemFromDB);
           
        }
        public IActionResult PayBill()
        {
            IEnumerable<Cart> objCartList = _db.cart;
            Bill bill = new Bill();
            bill.billAmount = 0;

            foreach (var item in objCartList)
            {
                bill.billAmount = bill.billAmount + item.price;
            }
            return View(bill);

           
        }

        public IActionResult OrderPlaced()
        {
            return View();
        }

        public IActionResult Signup()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Signup(Customer obj)
        {
            if (obj.CustomerName == obj.CustomerEmail)
            {
                ModelState.AddModelError("CustomerName", "The customer name cannot exactly match email.");
            }
            if (ModelState.IsValid)
            {
                _db.customer.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Customer Registeration successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);


        }

        public IActionResult Login(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var itemFromDB = _db.customer.Find(id);
            if (itemFromDB == null)
            {
                return NotFound();
            }

            return View(itemFromDB);

            
        }






    }
}
