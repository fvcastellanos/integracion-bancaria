using IntegracionBancaria.Domain;
using IntegracionBancaria.Model.Data.Dapper;
using IntegracionBancaria.Model.Domain;
using Microsoft.Extensions.Logging;

namespace IntegracionBancaria.Service
{
    public class ServicioInicioSesion
    {
        private readonly ILogger _logger;
        private readonly UsuarioDao _usuarioDao;
        private readonly PerfilDao _perfilDao;
        private readonly ServicioCriptografia _servicioCriptografia;

        public ServicioInicioSesion(ILogger<ServicioInicioSesion> logger, UsuarioDao usuarioDao, PerfilDao perfilDao, ServicioCriptografia servicioCriptografia)
        {
            _logger = logger;
            _usuarioDao = usuarioDao;
            _perfilDao = perfilDao;
            _servicioCriptografia = servicioCriptografia;
        }

        public Result<string, Perfil> ObtenerPerfilUsuario(string usuario, string clave)
        {
            var usr = ObtenerUsuario(usuario, clave);
            if (usr == null)
            {
                return Result<string, Perfil>.ForFailure("Usuario no encontrado");
            }

            var perfil = _perfilDao.BuscarPorUsuario(usuario);

            if (perfil == null)
            {
                return Result<string, Perfil>.ForFailure("El perfil del usuario: " + usr + " no se ha encontrado");
            }

            return Result<string,Perfil>.ForSuccess(perfil);
        }

        private Usuario ObtenerUsuario(string usuario, string clave)
        {
            _logger.LogInformation("Validando credenciales del usuario: {0}", usuario);
            var usr = _usuarioDao.BuscarPorUsuario(usuario);
            var claveCifrada = _servicioCriptografia.CodificarASha256(clave);
            if (usr.Clave.Equals(claveCifrada))
            {
                _logger.LogInformation("Usuario {0}, valido", usuario);
                return usr;
            }

            _logger.LogError("Usuario {0} no encontrado con las credenciales", usuario );
            return null;
        }
    }
}