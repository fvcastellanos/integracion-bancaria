using Microsoft.AspNetCore.Mvc;

namespace IntegracionBancaria.Controllers
{
    public class InicioController : SesionController
    {
        public IActionResult Index()
        {
            var perfil = ObtenerPerfilUsuario();
            
            return View(perfil);
        }

        public IActionResult Consultas()
        {
            return View();
        }

        public IActionResult Pagos()
        {
            return View();
        }

        public IActionResult Salir()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}