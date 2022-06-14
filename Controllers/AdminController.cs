using Microsoft.AspNetCore.Mvc;

namespace KMAstationeryStore.Controllers
{
    public class AdminController : Controller
    {


        public IActionResult HomePage()
        {

            return View();
        }
    }
}
