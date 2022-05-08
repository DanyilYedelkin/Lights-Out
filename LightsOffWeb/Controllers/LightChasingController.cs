using Microsoft.AspNetCore.Mvc;

namespace LightsOffWeb.Controllers
{
    public class LightChasingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
