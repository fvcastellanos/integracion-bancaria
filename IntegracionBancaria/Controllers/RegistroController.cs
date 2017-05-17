using System.Collections;
using System.Collections.Generic;
using IntegracionBancaria.Model.Domain;
using IntegracionBancaria.Model.Views;
using IntegracionBancaria.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IntegracionBancaria.Controllers
{
    public class RegistroController : Controller
    {
        private ServicioBanco _servicioBanco;

        public RegistroController(ServicioBanco servicioBanco)
        {
            _servicioBanco = servicioBanco;
        }

        public IActionResult Registro()
        {
            
            var registroViewModel = new RegistroViewModel() { Bancos = ObtenerListadoBancos() };
            return View(registroViewModel);
        }

        public IActionResult Registrarse(RegistroViewModel registroViewModel)
        {
            registroViewModel.Bancos = ObtenerListadoBancos();

            if (ModelState.IsValid)
            {

            }

            return View("Registro", registroViewModel);
        }

        private SelectList ObtenerListadoBancos()
        {
            var obtenerBancosResult = _servicioBanco.ObtenerBancosActivos();
            var items = CrearListaVacia();

            if (obtenerBancosResult.IsSuccess())
            {
                var bancos = obtenerBancosResult.GetPayload();
                items = CrearListaBancos(bancos);
            }
            
            return items;
        }

        private SelectList CrearListaBancos(IEnumerable lista) {
            return new SelectList(lista, "Id", "Nombre");
        }

        private SelectList CrearListaVacia()
        {
            var banco = new Banco() { Id = 0, Nombre = "Sin Valor" };
            var lista = new List<Banco>();
            lista.Add(banco);

            return CrearListaBancos(lista);
        }
        
    }
}