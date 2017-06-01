
using System.Collections.Generic;
using IntegracionBancaria.Model.Domain;
using IntegracionBancaria.Model.Domain.Mock;
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
            List<Model.Domain.Banco> bancos = (List<Model.Domain.Banco>) _servicioBanco.ObtenerBancosUsuario(usuario).GetPayload();

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
                        "",
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
            List<Model.Domain.Banco> bancos = (List<Model.Domain.Banco>) _servicioBanco.ObtenerBancosUsuario(usuario).GetPayload();

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
                        "",
                        autorizacion
                        );
            
            _servicioTransaccion.CrearTransaccionDetalle(transaccionDetalle);

            var pagoViewModel = new PagoViewModel
            {
                Autorizacion = autorizacion
            };
            return View("Pagar", pagoViewModel);
        }

        public IActionResult PagoServicios()
        {
            var perfil = ObtenerPerfilUsuario();
            var usuario = ObtenerUsuario();
            var bancos = _servicioBanco.ObtenerBancosUsuario(usuario).GetPayload();
            var servicios = new List<Servicio>();
            servicios.Add(new Servicio {
                Codigo = "AG",
                Nombre = "AGUA"
            });
            servicios.Add(new Servicio {
                Codigo = "LZ",
                Nombre = "LUZ"
            });
            servicios.Add(new Servicio {
                Codigo = "TE",
                Nombre = "TELEFONO"
            });
            var tipoDocumentos = new List<TipoDocumento>();
            tipoDocumentos.Add(new TipoDocumento {
                Codigo = 1,
                Nombre = "TARJETA"
            });
            tipoDocumentos.Add(new TipoDocumento {
                Codigo = 2,
                Nombre = "CUENTA"
            });

            var pagoViewModel = new PagoViewModel
            {
                Bancos = bancos,
                Usuario = usuario,
                Servicios = servicios,
                TipoDocumentos = tipoDocumentos
            };

            return View(pagoViewModel);
        }

       [HttpPost]
        public IActionResult PagarServicio(IFormCollection formCollection)
        {
            var perfil = ObtenerPerfilUsuario();
            var usuario = ObtenerUsuario();
            List<Model.Domain.Banco> bancos = (List<Model.Domain.Banco>) _servicioBanco.ObtenerBancosUsuario(usuario).GetPayload();

            string[] codigo = formCollection["Codigo"];
            string tipoServicio = codigo[0];
            string servicio = formCollection["servicios"];
            string bancosSeleccionado = codigo[1];
            string cuenta = formCollection["cuentas"];
            string monto = formCollection["monto"];
            string descripcion = formCollection["descripcion"];
            string autorizacion = System.Guid.NewGuid().ToString();

            long transaccion = _servicioTransaccion.CrearTransaccion(new Transaccion(4, perfil.UsuarioId, descripcion));

            var transaccionDetalle = new TransaccionDetalle(transaccion,
                        0,
                        "",
                        bancos.Find(banco => banco.Codigo == bancosSeleccionado).Id,
                        cuenta,
                        "Q",
                        double.Parse(monto),
                        servicio,
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