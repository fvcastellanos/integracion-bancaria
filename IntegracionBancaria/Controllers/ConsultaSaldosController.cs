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
            var bancos = _servicioBanco.ObtenerBancosActivos().GetPayload();
            var consultaSaldos = new ConsultaSaldosViewModel {
                Bancos = bancos,
                Usuario = ObtenerUsuario()
            };

            return View(consultaSaldos);
        }

    }
}
