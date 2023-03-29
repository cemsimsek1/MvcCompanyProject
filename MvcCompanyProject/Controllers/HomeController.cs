using Microsoft.AspNetCore.Mvc;

namespace MvcCompanyProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
