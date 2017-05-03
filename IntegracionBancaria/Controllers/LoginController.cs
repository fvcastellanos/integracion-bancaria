
using Microsoft.AspNetCore.Mvc;

namespace IntegracionBancaria.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registro()
        {
            

            return View();
        }
    }
}