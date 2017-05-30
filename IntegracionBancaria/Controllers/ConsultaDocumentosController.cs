using IntegracionBancaria.Service;
using Microsoft.AspNetCore.Mvc;

namespace IntegracionBancaria.Controllers
{
    public class ConsultaDocumentos : SesionController
    {
        [HttpGet("/ConsultaDocumentos/{documento}")]
        public IActionResult Index(string documento)
        {
            var modelo = ServicioMock.CrearDocumento(documento);
            return View(modelo);
        }

    }
}