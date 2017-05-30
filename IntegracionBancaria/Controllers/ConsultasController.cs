using System.Collections.Generic;
using IntegracionBancaria.Model.Domain;
using IntegracionBancaria.Model.Views;
using IntegracionBancaria.Service;
using Microsoft.AspNetCore.Mvc;

namespace IntegracionBancaria.Controllers
{
    public class ConsultasController : SesionController
    {
        private readonly ServicioBanco _servicioBanco;

        public ConsultasController(ServicioBanco servicioBanco)
        {
            _servicioBanco = servicioBanco;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/consultas/saldos")]
        public IActionResult Saldos()
        {
            var modelo = CrearConsultaSaldosModelo();
            return View("saldos", modelo);
        }

        [HttpPost("/consultas/estado-cuenta")]
        public IActionResult ObtenerEstadoCuenta(string Codigo, string Numero)
        {
            var modelo = ConstruirEstadoCuentaModelo();

            if (ModelState.IsValid)
            {
                modelo.Movimientos = ServicioMock.ObtenerMovimientos();
            }

            return View("estado-cuenta", modelo);
        }

        [HttpGet("/consultas/estado-cuenta")]
        public IActionResult EstadoCuenta()
        {
            var modelo = ConstruirEstadoCuentaModelo();
            return View("estado-cuenta", modelo);
        }

        private EstadoCuentaViewModel ConstruirEstadoCuentaModelo()
        {
            var usuario = ObtenerUsuario();
            var perfil = ObtenerPerfilUsuario();
            var bancos = _servicioBanco.ObtenerBancosUsuario(usuario).GetPayload();
            var cuentas =ServicioMock.ConstruirListadoCuentas(perfil);

            var modelo = new EstadoCuentaViewModel()
            {
                Bancos = bancos,
                Cuentas = cuentas,
                Movimientos = new List<Movimiento>()
            };

            return modelo;
        }

        private ConsultaSaldosViewModel CrearConsultaSaldosModelo()
        {
            var perfil = ObtenerPerfilUsuario();
            var usuario = ObtenerUsuario();
            var bancos = _servicioBanco.ObtenerBancosUsuario(usuario).GetPayload();
            var consultaSaldos = new ConsultaSaldosViewModel {
                Bancos = bancos,
                Usuario = usuario
            };

            return consultaSaldos;
        }
        
        
    }
}