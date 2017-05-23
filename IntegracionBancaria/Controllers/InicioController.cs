using Microsoft.AspNetCore.Mvc;

namespace IntegracionBancaria.Controllers
{
    public class InicioController : SesionController
    {
        public IActionResult Index()
        {
            var perfil = ObtenerUsuario();
            
            return View(perfil);
        }

        public IActionResult Salir()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}