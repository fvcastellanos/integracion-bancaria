using IntegracionBancaria.Service;
using IntegracionBancaria.Model.Views;
using Microsoft.AspNetCore.Mvc;

namespace IntegracionBancaria.Controllers
{
    public class AgregarBancoController : SesionController
    {
        readonly ServicioBanco _servicioBanco;
        readonly ServicioRegistro _servicioRegistro;

        public AgregarBancoController(ServicioBanco servicioBanco, ServicioRegistro servicioRegistro)
        {
            _servicioBanco = servicioBanco;
            _servicioRegistro =  servicioRegistro;
        }

        public IActionResult Index()
        {
            var model = CrearModelo();
            return View(model);
        }

        public IActionResult Agregar(string codigo)
        {
            if ((codigo != null) && (!codigo.Equals("")))
            {
                var resultado = _servicioRegistro.AsociarBancoUsuario(codigo, ObtenerUsuario());

                if (!resultado.Equals(""))
                {
                    ModelState.AddModelError("Application Error", resultado);
                }

                return View("Index", CrearModelo());

            }

            ModelState.AddModelError("Application Error", "Seleccione un banco");

            return View("Index", CrearModelo());
        }


        private AgregarBancoViewModel CrearModelo()
        {
            var perfil = ObtenerPerfilUsuario();
            var usuario = ObtenerUsuario();
            var bancos = _servicioBanco.ObtenerBancosActivos();
            var bancosSuscritos = _servicioBanco.ObtenerBancosUsuario(usuario);

            var model = new AgregarBancoViewModel()
                {
                    Bancos = bancos.GetPayload(),
                    BancosSuscritos = bancosSuscritos.GetPayload(),
                    PerfilUsuario = perfil
                };
            
            return model;
        }
    }
}