
using System.Collections.Generic;
using IntegracionBancaria.Model.Domain;
using IntegracionBancaria.Model.Views;
using IntegracionBancaria.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Collections;
using Newtonsoft.Json;

namespace IntegracionBancaria.Controllers
{
    public class LoginController : Controller
    {
        private ServicioBanco _servicioBanco;

        private ServicioInicioSesion _servicioInicioSesion;

        public LoginController(ServicioBanco servicioBanco, ServicioInicioSesion servicioInicioSesion) {
            _servicioBanco = servicioBanco;
            _servicioInicioSesion = servicioInicioSesion;
        }

        public IActionResult Index()
        {
            return View("Login");
        }

        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {

                var result = _servicioInicioSesion.ObtenerPerfilUsuario(login.Usuario, login.Clave);
                if (result.IsSuccess())
                {
                    HttpContext.Session.SetString("perfil", JsonConvert.SerializeObject(result.GetPayload()));
                    return RedirectToAction("Index", "Inicio");
                }

                 ModelState.AddModelError("Application Error", result.GetFailure());
            }

            return View("Login");
        }

    }
}