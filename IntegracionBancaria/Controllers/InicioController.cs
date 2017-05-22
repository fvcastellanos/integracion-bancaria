using Microsoft.AspNetCore.Mvc;

namespace IntegracionBancaria.Controllers
{
    public class InicioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}