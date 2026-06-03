using Microsoft.AspNetCore.Mvc;

namespace ViewExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("Home")]
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
