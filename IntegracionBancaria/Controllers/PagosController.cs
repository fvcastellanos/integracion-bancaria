
using System.Collections.Generic;
using IntegracionBancaria.Model.Domain;
using IntegracionBancaria.Model.Views;
using IntegracionBancaria.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegracionBancaria.Controllers
{
    public class PagosController : SesionController
    {
        private readonly ServicioBanco _servicioBanco;
        private readonly ServicioTransaccion _servicioTransaccion;

        public PagosController(ServicioBanco servicioBanco,
                                        ServicioTransaccion servicioTransaccion)
        {
            _servicioBanco = servicioBanco;
            _servicioTransaccion = servicioTransaccion;
        }

        public IActionResult PagoTarjeta()
        {
            var perfil = ObtenerPerfilUsuario();
            var usuario = ObtenerUsuario();
            var bancos = _servicioBanco.ObtenerBancosUsuario(usuario).GetPayload();
            var pagoViewModel = new PagoViewModel
            {
                Bancos = bancos,
                Usuario = usuario
            };

            return View(pagoViewModel);
        }

        [HttpPost]
        public IActionResult PagarTarjeta(IFormCollection formCollection)
        {
            var perfil = ObtenerPerfilUsuario();
            var usuario = ObtenerUsuario();
            List<Banco> bancos = (List<Banco>) _servicioBanco.ObtenerBancosUsuario(usuario).GetPayload();

            string[] bancosSeleccionados = formCollection["Codigo"];
            string tarjeta = formCollection["tarjetas"];
            string cuenta = formCollection["cuentas"];
            string monto = formCollection["monto"];
            string descripcion = formCollection["descripcion"];
            string autorizacion = System.Guid.NewGuid().ToString();

            long transaccion = _servicioTransaccion.CrearTransaccion(new Transaccion(1, perfil.UsuarioId, descripcion));

            var transaccionDetalle = new TransaccionDetalle(transaccion,
                        bancos.Find(banco => banco.Codigo == bancosSeleccionados[0]).Id,
                        tarjeta,
                        bancos.Find(banco => banco.Codigo == bancosSeleccionados[1]).Id,
                        cuenta,
                        "Q",
                        double.Parse(monto),
                        autorizacion
                        );
            
            _servicioTransaccion.CrearTransaccionDetalle(transaccionDetalle);

            var pagoViewModel = new PagoViewModel
            {
                Autorizacion = autorizacion
            };
            return View("Pagar", pagoViewModel);
        }

        public IActionResult PagoPrestamo()
        {
            var perfil = ObtenerPerfilUsuario();
            var usuario = ObtenerUsuario();
            var bancos = _servicioBanco.ObtenerBancosUsuario(usuario).GetPayload();
            var pagoViewModel = new PagoViewModel
            {
                Bancos = bancos,
                Usuario = usuario
            };

            return View(pagoViewModel);
        }

       [HttpPost]
        public IActionResult PagarPrestamo(IFormCollection formCollection)
        {
            var perfil = ObtenerPerfilUsuario();
            var usuario = ObtenerUsuario();
            List<Banco> bancos = (List<Banco>) _servicioBanco.ObtenerBancosUsuario(usuario).GetPayload();

            string[] bancosSeleccionados = formCollection["Codigo"];
            string tarjeta = formCollection["prestamos"];
            string cuenta = formCollection["cuentas"];
            string monto = formCollection["monto"];
            string descripcion = formCollection["descripcion"];
            string autorizacion = System.Guid.NewGuid().ToString();

            long transaccion = _servicioTransaccion.CrearTransaccion(new Transaccion(2, perfil.UsuarioId, descripcion));

            var transaccionDetalle = new TransaccionDetalle(transaccion,
                        bancos.Find(banco => banco.Codigo == bancosSeleccionados[0]).Id,
                        tarjeta,
                        bancos.Find(banco => banco.Codigo == bancosSeleccionados[1]).Id,
                        cuenta,
                        "Q",
                        double.Parse(monto),
                        autorizacion
                        );
            
            _servicioTransaccion.CrearTransaccionDetalle(transaccionDetalle);

            var pagoViewModel = new PagoViewModel
            {
                Autorizacion = autorizacion
            };
            return View("Pagar", pagoViewModel);
        }
    }
}