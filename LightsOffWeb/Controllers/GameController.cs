using Microsoft.AspNetCore.Mvc;

namespace LightsOffWeb.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
