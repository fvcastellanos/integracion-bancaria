using System.Collections.Generic;
using IntegracionBancaria.Domain;
using IntegracionBancaria.Model.Domain;
using IntegracionBancaria.Model.Views;
using IntegracionBancaria.Service;
using Microsoft.AspNetCore.Mvc;

namespace IntegracionBancaria.Controllers
{
    public class EstadoCuentaController : SesionController
    {
        private ServicioBanco _servicioBanco;

        public EstadoCuentaController(ServicioBanco servicioBanco)
        {
            _servicioBanco = servicioBanco;
        }

        public IActionResult Index()
        {   
            var modelo = ConstruirModelo();
            return View(modelo);
        }

        public IActionResult Obtener(string codigo, string numero)
        {
            var modelo = ConstruirModelo();

            if (ModelState.IsValid)
            {
                modelo.Movimientos = ServicioMock.ObtenerMovimientos();
            }

            return View("Index", modelo);
        }

        private EstadoCuentaViewModel ConstruirModelo()
        {
            var usuario = ObtenerUsuario();
            var perfil = ObtenerPerfilUsuario();
            var bancos = _servicioBanco.ObtenerBancosUsuario(usuario).GetPayload();
            var cuentas = ConstruirListadoCuentas(perfil);

            var modelo = new EstadoCuentaViewModel()
            {
                Bancos = bancos,
                Cuentas = cuentas,
                Movimientos = new List<Movimiento>()
            };

            return modelo;
        }

        private IList<Cuenta> ConstruirListadoCuentas(Perfil perfil)
        {
            var cuentas = new List<Cuenta>();
            cuentas.Add(new Cuenta() {
                Numero = "GTQ - 4342343-K",
                NombreCuenta = perfil.Nombres + " " + perfil.Apellidos,
                Moneda = "GTQ"
            });

            cuentas.Add(new Cuenta(){
                Numero = "USD - 939198-987-4224",
                NombreCuenta = perfil.Nombres + " " + perfil.Apellidos,
                Moneda = "USD"
            });

            return cuentas;
        }
    }
}
