
using Microsoft.AspNetCore.Mvc;

namespace IntegracionBancaria.Controllers
{
    public class PagoTarjetaCreditoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}