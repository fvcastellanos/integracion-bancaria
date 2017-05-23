using IntegracionBancaria.Service;
using Microsoft.AspNetCore.Mvc;

namespace IntegracionBancaria.Controllers
{
    public class ConsultaSaldos : Controller
    {
        private readonly ServicioBanco _servicioBanco;
        public ConsultaSaldos(ServicioBanco servicioBanco)
        {
            _servicioBanco = servicioBanco;
        }

        public IActionResult Index()
        {
            var bancos = _servicioBanco.ObtenerBancosActivos().GetPayload();
            var consultaSaldos = new Model.Views.ConsultaSaldosViewModel {
                Bancos = bancos,
            };

            return View(consultaSaldos);
        }

    }
}
