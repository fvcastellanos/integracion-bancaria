using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegracionBancaria.Model;
using IntegracionBancaria.Model.Domain;
using IntegracionBancaria.Model.Views;
using IntegracionBancaria.Service;
using Microsoft.AspNetCore.Mvc;

namespace IntegracionBancaria.Controllers
{
    public class HomeController : Controller
    {
        private readonly ServicioComentario _servicioComentario;

        public HomeController(ServicioComentario servicioComentario)
        {
            _servicioComentario = servicioComentario;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Vision()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Mision()
        {
            return View();
        }

        public IActionResult TipoCambio()
        {
            // Obtener tipo de cambio del servicio web
            TipoCambio tipoCambio = new TipoCambio("Dolar", 7.25, 7.80, "USD");
            var tiposCambio = new List<TipoCambio>();
            tiposCambio.Add(tipoCambio);

            return View(tiposCambio);
        }

        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ObtenerComentario(Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                var result = _servicioComentario.GuardarComentario(comentario.Nombre, "ip", 
                    comentario.Correo, comentario.Texto);
                
                if (result.IsSuccess()) 
                {
                    return View("ContactoConfirmacion", comentario);
                }

                ViewData["error"] = result.GetFailure().Message;
            }

            return View("Contacto", comentario);
        }


        public IActionResult Error()
        {
            return View();
        }
    }
}
