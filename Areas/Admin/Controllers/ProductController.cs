using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace ANPDB.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")] // optional but recommended
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
