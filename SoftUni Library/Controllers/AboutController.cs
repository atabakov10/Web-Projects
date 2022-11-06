using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View("About");
        }
    }
}
