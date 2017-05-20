using System;
using IntegracionBancaria.Domain;
using IntegracionBancaria.Model.Data.Dapper;
using IntegracionBancaria.Model.Domain;
using IntegracionBancaria.Model.Views;
using Microsoft.Extensions.Logging;

namespace IntegracionBancaria.Service
{
    public class ServicioRegistro
    {
        private readonly ILogger _logger;
        private readonly PerfilDao _perfilDao;
        private readonly UsuarioDao _usuarioDao;

        public ServicioRegistro(PerfilDao perfilDao, UsuarioDao usuarioDao, ILogger<ServicioRegistro> logger)
        {
            _logger = logger;
            _perfilDao = perfilDao;
            _usuarioDao = usuarioDao;
        }

        public Result<Exception, Perfil> RegistrarUsuario(RegistroViewModel registroViewModel)
        {
            try
            {
                var registro = registroViewModel.Registro;
                _logger.LogInformation("Registranto usuario: {0}", registro.Nombres);
                // Creando usuario
                var usuarioId = CrearUsuario(registro, _usuarioDao);
            }
            catch (Exception ex)
            {
                return Result<Exception, Perfil>.ForFailure(ex);
            }
            
            return null;
        }

        private Usuario ConstruirUsuario(Registro registro)
        {
            var usuario = new Usuario() { Usr = registro.Usuario, Clave = registro.Clave };
            return usuario;
        }

        private Perfil ConstruirPerfil(long usuarioId, Registro registro)
        {
            var perfil = new Perfil() { UsuarioId = usuarioId, Nombres = registro.Nombres, Apellidos = registro.Apellidos, Correo = registro.Correo };
            return perfil;
        }

        private long CrearUsuario(Registro registro, UsuarioDao usuarioDao)
        {
            var usuario = ConstruirUsuario(registro);
            var usuarioId = usuarioDao.CrearUsuario(usuario);

            return usuarioId;
        }

        private long CrearPerfil(long usuarioId, Registro registro, PerfilDao perfilDao)
        {
            var perfil = ConstruirPerfil(usuarioId, registro);
            var perfilId = perfilDao.GuardarPerfil(perfil);

            return perfilId;
        }
    }
}