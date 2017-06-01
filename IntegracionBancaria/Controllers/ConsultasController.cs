using System.Collections.Generic;
using IntegracionBancaria.Model.Domain;
using IntegracionBancaria.Model.Views;
using IntegracionBancaria.Service;
using Microsoft.AspNetCore.Mvc;

namespace IntegracionBancaria.Controllers
{
    [Route("/[controller]")]
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

        [HttpGet("/saldos")]
        public IActionResult Saldos()
        {
            var modelo = CrearConsultaSaldosModelo();
            return View("saldos", modelo);
        }

        [HttpPost("/estado-cuenta")]
        public IActionResult ObtenerEstadoCuenta(string Codigo, string Numero)
        {
            var modelo = ConstruirEstadoCuentaModelo();

            if (ModelState.IsValid)
            {
                modelo.Movimientos = ServicioMock.ObtenerMovimientos();
            }

            return View("estado-cuenta", modelo);
        }

        [HttpGet("/estado-cuenta")]
        public IActionResult EstadoCuenta()
        {
            var modelo = ConstruirEstadoCuentaModelo();
            return View("estado-cuenta", modelo);
        }

        [HttpGet("/saldo-tarjetas")]
        public IActionResult SaldoTarjetas() {
            var modelo = CrearConsultaTarjetasViewModel();

            return View("saldo-tarjetas", modelo);
        }

        [HttpPost("/saldo-tarjetas")]
        public IActionResult ConsultarSaldoTarjetas(string Codigo, string Numero) {
            var modelo = CrearConsultaTarjetasViewModel();

            if (ModelState.IsValid)
            {
                var saldo = ServicioMock.ConsultarSaldoTarjetas(ObtenerPerfilUsuario(), Codigo);
                modelo.SaldoTarjetas = saldo;
            }

            return View("saldo-tarjetas", modelo);
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

        private ConsultaTarjetasViewModel CrearConsultaTarjetasViewModel()
        {
            var perfil = ObtenerPerfilUsuario();
            var usuario = ObtenerUsuario();
            var bancos = _servicioBanco.ObtenerBancosUsuario(usuario).GetPayload();
            var tarjetas = ServicioMock.ConstruirListadoCuentas(perfil);
            var model = new ConsultaTarjetasViewModel() {
                Bancos = bancos,
                Tarjetas = tarjetas
            };

            return model;
        }
        
        
    }
}