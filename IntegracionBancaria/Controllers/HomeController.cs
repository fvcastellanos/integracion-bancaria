using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegracionBancaria.Model;
using Microsoft.AspNetCore.Mvc;

namespace IntegracionBancaria.Controllers
{
    public class HomeController : Controller
    {
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
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
