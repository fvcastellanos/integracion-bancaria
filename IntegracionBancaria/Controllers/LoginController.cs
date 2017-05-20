
using System.Collections.Generic;
using IntegracionBancaria.Model.Domain;
using IntegracionBancaria.Model.Views;
using IntegracionBancaria.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Collections;

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

    }
}