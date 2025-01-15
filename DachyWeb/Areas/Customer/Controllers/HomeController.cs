using Dachy.DataAccess.Repository.IRepository;
using Dachy.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DachyWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Roofs()
        {
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category").Where(p=>p.CategoryId ==1);
            return View(productList);
        }
        public IActionResult Gutters()
        {
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category").Where(p => p.CategoryId == 4);
            return View(productList);
        }
        public IActionResult Accessories()
        {
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category").Where(p => p.CategoryId == 11);
            return View(productList);
        }

        public IActionResult DetailsGutters(int productId)
        {
            Product product = _unitOfWork.Product.Get(u => u.ProductId == productId, includeProperties: "Category");
            return View(product);
        }

        public IActionResult DetailsAccessories(int productId)
        {
            Product product = _unitOfWork.Product.Get(u => u.ProductId == productId, includeProperties: "Category");
            return View(product);
        }

        public IActionResult DetailsRoofs(int productId)
        {
            Product product = _unitOfWork.Product.Get(u=>u.ProductId== productId, includeProperties: "Category");
            return View(product);
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
