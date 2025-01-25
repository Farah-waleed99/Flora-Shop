using Master.Data;
using Master.Models;
using Master.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Master.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext db;
        public HomeController(AppDbContext _db)
        {

            db = _db;
        }

        public IActionResult Index()
        {
            CategoryProduct model = new CategoryProduct
            {
                Products = db.Products.ToList(),

                Categories = db.Categories.ToList()
            };
            return View(model);
        }


        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            return View();
        }

        public IActionResult ProductDetails(int? id)
        {
            if (id == null) { return RedirectToAction("Index"); }
            var data = db.Products.Find(id);
            if (data == null) { return RedirectToAction("Index"); }

            return View(data);

        }


        public IActionResult Products(int? id)
        {
            if (id == null) { return RedirectToAction("Index"); }
            var data = db.Products.Find(id);
            if (data == null) { return RedirectToAction("Index"); }

            return View(data);

        }

        public IActionResult Listing(int id)
        {
            return View(db.Products.ToList().Where(x => x.CategoryId == id));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
