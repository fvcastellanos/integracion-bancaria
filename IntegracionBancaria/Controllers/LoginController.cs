
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

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registro()
        {
            

            if(obtenerBancosResult.IsSuccess())
            {
                var registroViewModel = new RegistroViewModel();

                registroViewModel.Bancos = options;

            }


        

            return View(registroViewModel);
        }

        private IList<SelectListItem> ObtenerListadoBancos()
        {
            var obtenerBancosResult = _servicioBanco.ObtenerBancosActivos();
            IList<SelectListItem> items = null;

            if (obtenerBancosResult.IsSuccess())
            {
                var bancos = obtenerBancosResult.GetPayload();
                items = from banco in bancos
                    select new { Text = banco.Nombre, Value = banco.Id.ToString() }
                    as List<SelectListItem>();

                items = bancos.Select(banco => new SelectListItem() { });
            }
        }
    }
}