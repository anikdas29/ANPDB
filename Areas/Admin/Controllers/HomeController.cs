using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace ANPDB.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")] // optional but recommended
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
