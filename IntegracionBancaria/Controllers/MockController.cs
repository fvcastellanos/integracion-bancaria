using System.Collections.Generic;
using IntegracionBancaria.Model.Domain.Mock;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IntegracionBancaria.Controllers
{
    [Route("api/[controller]")]
    public class MockController : Controller
    {
        public MockController()
        {
        }

        [HttpGet("Usuarios/{usuarioId}/Bancos/{bancoId}/Cuentas")]
        public List<Cuenta> GetCuentas(long usuarioId, long bancoId)
        {
            var usuarios = JsonConvert.DeserializeObject<List<Usuario>>(System.IO.File.ReadAllText("./Resources/usuarios.json"));
            var usuario = usuarios.Find(u => u.Id == usuarioId);
            var bancos = usuario.Bancos.Find(b => b.Id == bancoId);
            
            return bancos.Cuentas;
        }

    }
}
