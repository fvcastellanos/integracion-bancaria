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
        }

    }
}
