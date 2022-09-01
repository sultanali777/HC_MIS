using Microsoft.AspNetCore.Mvc;

namespace HC_MIS.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}