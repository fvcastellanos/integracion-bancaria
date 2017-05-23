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

        [HttpGet("Usuarios/{usr}/Bancos/{banco}/Cuentas")]
        public List<Cuenta> GetCuentas(string usr, string banco)
        {
            var usuarios = JsonConvert.DeserializeObject<List<Usuario>>(System.IO.File.ReadAllText("./Resources/usuarios.json"));
            var usuario = usuarios.Find(u => u.Usr == usr);
            var bancos = usuario.Bancos.Find(b => b.Codigo == banco);
            
            return bancos.Cuentas;
        }

    }
}
