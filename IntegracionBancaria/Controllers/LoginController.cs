
using System.Collections.Generic;
using IntegracionBancaria.Model.Domain;
using IntegracionBancaria.Model.Views;
using IntegracionBancaria.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace IntegracionBancaria.Controllers
{
    public class LoginController : Controller
    {
        private ServicioBanco _servicioBanco;

        public LoginController(ServicioBanco servicioBanco) {
            _servicioBanco = servicioBanco;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registro()
        {
            
            var registroViewModel = new RegistroViewModel() { Bancos = ObtenerListadoBancos() };
            return View(registroViewModel);
        }

        public IActionResult Registrarse(RegistroViewModel registroViewModel)
        {
            if (ModelState.IsValid)
            {

            }

            return View("Registro", registroViewModel);
        }

        private IEnumerable<SelectListItem> ObtenerListadoBancos()
        {
            var obtenerBancosResult = _servicioBanco.ObtenerBancosActivos();
            IEnumerable<SelectListItem> items = CrearListaVacia();

            if (obtenerBancosResult.IsSuccess())
            {
                var bancos = obtenerBancosResult.GetPayload();
                items = bancos.Select(banco => new SelectListItem() {  Text = banco.Nombre, Value = banco.Id.ToString() });
            }
            
            return items;
        }

        private IEnumerable<SelectListItem> CrearListaVacia()
        {
            var item = new SelectListItem() { Text = "Sin valor", Value = "0" };
            var lista = new List<SelectListItem>();
            lista.Add(item);

            return lista;           
        }
    }
}