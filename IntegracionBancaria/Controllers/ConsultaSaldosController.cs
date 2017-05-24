using IntegracionBancaria.Model.Views;
using IntegracionBancaria.Service;
using Microsoft.AspNetCore.Mvc;

namespace IntegracionBancaria.Controllers
{
    public class ConsultaSaldos : SesionController
    {
        private readonly ServicioBanco _servicioBanco;

        public ConsultaSaldos(ServicioBanco servicioBanco)
        {
            _servicioBanco = servicioBanco;
        }

        public IActionResult Index()
        {
            var perfil = ObtenerPerfilUsuario();
            var usuario = ObtenerUsuario();
            var bancos = _servicioBanco.ObtenerBancosUsuario(usuario).GetPayload();
            var consultaSaldos = new ConsultaSaldosViewModel {
                Bancos = bancos,
                Usuario = usuario
            };

            return View(consultaSaldos);
        }

    }
}
