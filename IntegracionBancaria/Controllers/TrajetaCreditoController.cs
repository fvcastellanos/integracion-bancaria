
using System.Collections.Generic;
using IntegracionBancaria.Model.Domain;
using IntegracionBancaria.Model.Views;
using IntegracionBancaria.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegracionBancaria.Controllers
{
    public class TarjetaCreditoController : SesionController
    {
        private readonly ServicioBanco _servicioBanco;
        private readonly ServicioTransaccion _servicioTransaccion;

        public TarjetaCreditoController(ServicioBanco servicioBanco,
                                        ServicioTransaccion servicioTransaccion)
        {
            _servicioBanco = servicioBanco;
            _servicioTransaccion = servicioTransaccion;
        }

        public IActionResult Index()
        {
            var perfil = ObtenerPerfilUsuario();
            var usuario = ObtenerUsuario();
            var bancos = _servicioBanco.ObtenerBancosUsuario(usuario).GetPayload();
            var pagoTarjetaCredito = new PagoTarjetaCreditoViewModel
            {
                Bancos = bancos,
                Usuario = usuario
            };

            return View(pagoTarjetaCredito);
        }


        [HttpPost]
        public IActionResult Pagar(IFormCollection formCollection)
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

            var pagoTarjetaCredito = new PagoTarjetaCreditoViewModel
            {
                Autorizacion = autorizacion
            };

            

            return View(pagoTarjetaCredito);
        }
    }
}