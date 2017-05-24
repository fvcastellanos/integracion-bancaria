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
        private readonly ServicioBanco _servicioBanco;
        private readonly ServicioRegistro _servicioRegistro;

        public RegistroController(ServicioBanco servicioBanco, ServicioRegistro servicioRegistro)
        {
            _servicioBanco = servicioBanco;
            _servicioRegistro = servicioRegistro;
        }

        public IActionResult Index()
        {
            var registroViewModel = new RegistroViewModel() { Bancos = ObtenerListadoBancos() };
            return View(registroViewModel);
        }

        public IActionResult Registrarse(RegistroViewModel registroViewModel)
        {
            registroViewModel.Bancos = ObtenerListadoBancos();

            if (ModelState.IsValid)
            {
                var result = _servicioRegistro.RegistrarUsuario(registroViewModel);
                
                if(result.IsSuccess())
                {
                    return View("Bienvenido", result.GetPayload());
                }

                 ModelState.AddModelError("Application Error", result.GetFailure());
            }

            return View("Index", registroViewModel);
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
            return new SelectList(lista, "Codigo", "Nombre");
        }

        private SelectList CrearListaVacia()
        {
            var banco = new Banco() { Codigo = "--", Nombre = "Sin Valor" };
            var lista = new List<Banco>();
            lista.Add(banco);

            return CrearListaBancos(lista);
        }
        
    }
}