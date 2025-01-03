using Microsoft.AspNetCore.Mvc;

namespace DachyWeb.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
