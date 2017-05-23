using IntegracionBancaria.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace IntegracionBancaria.Controllers
{
    public class SesionController : Controller
    {
        protected Perfil ObtenerUsuario()
        {
            Perfil perfil = new Perfil();
            var perfilSt = HttpContext.Session.GetString("perfil");
            if (perfilSt != null)
            {
                perfil = new Perfil();
                JsonConvert.PopulateObject(perfilSt, perfil);

                return perfil;
            }

            return perfil;
        }
    }
}