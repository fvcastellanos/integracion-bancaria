using IntegracionBancaria.Model.Data.Dapper;
using IntegracionBancaria.Model.Views;
using Microsoft.AspNetCore.Mvc;

namespace IntegracionBancaria.Controllers
{
    public class BitacoraController : SesionController
    {
        private BitacoraDao _bitacoraDao;

        public BitacoraController(BitacoraDao bitacoraDao)
        {
            _bitacoraDao = bitacoraDao;
        }

        public IActionResult Index()
        {
            var bitacoras = _bitacoraDao.ObtenerBitacoraUsuario(ObtenerUsuario());

            var modelo = new BitacoraViewModel() 
            {
                Bitacoras = bitacoras
            };

            return View(modelo);
        }
    }
}