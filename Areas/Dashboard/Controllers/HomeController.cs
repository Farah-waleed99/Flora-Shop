using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Master.Areas.Dashboard.Controllers
{

    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return RedirectToAction("Index", "Orders", new { area = "Dashboard" });
        }

    }
}
