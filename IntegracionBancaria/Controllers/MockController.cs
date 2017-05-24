using System.Collections.Generic;
using IntegracionBancaria.Model.Data.Dapper;
using IntegracionBancaria.Model.Domain.Mock;
using IntegracionBancaria.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IntegracionBancaria.Controllers
{

    [Route("api/[controller]")]
    public class MockController : Controller
    {
        private readonly PerfilDao _perfilDao;

        public MockController(PerfilDao perfilDao)
        {
            _perfilDao = perfilDao;
        }

        [HttpGet("Usuarios/{usr}/Bancos/{banco}/Cuentas")]
        public IList<Cuenta> GetCuentas(string usr, string banco)
        {
            var perfil = _perfilDao.BuscarPorUsuario(usr);
            return ServicioMock.ConsultarSaldos(perfil, banco);
            // var usuarios = JsonConvert.DeserializeObject<List<Usuario>>(System.IO.File.ReadAllText("./Resources/usuarios.json"));
            // var usuario = usuarios.Find(u => u.Usr == usr);
            // var bancos = usuario.Bancos.Find(b => b.Codigo == banco);
            
            // return bancos.Cuentas;
        }

    }
}
