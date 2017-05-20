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

        public Result<string, Perfil> RegistrarUsuario(RegistroViewModel registroViewModel)
        {
            try
            {
                var registro = registroViewModel.Registro;

                _logger.LogInformation("Registranto usuario: {0}", registro.Nombres);

                if(UsuarioExistente(registro.Usuario, _usuarioDao))
                {
                    return Result<string, Perfil>.ForFailure("Usuario existente");
                }

                // Creando usuario
                var usuario = CrearUsuario(registro, _usuarioDao);
                var perfil = CrearPerfil(usuario, registro, _perfilDao);

                _usuarioDao.AsociarBancoUsuario(registro.BancoId, usuario.Id, "demo-demo");

                return Result<string, Perfil>.ForSuccess(perfil);
            }
            catch (Exception ex)
            {
                return Result<string, Perfil>.ForFailure(ex.Message);
            }
        }

        private bool UsuarioExistente(string usr, UsuarioDao usuarioDao)
        {
            var usuario = usuarioDao.BuscarPorUsuario(usr);
            _logger.LogInformation("Verificando existencia del usuario: {0}", usr);

            if (usuario != null)
            {
                _logger.LogInformation("Usuario: {0}, ya existe", usr);
                return true;
            }

            _logger.LogInformation("Usuario {0}, inexistente");
            return false;
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

        private Usuario CrearUsuario(Registro registro, UsuarioDao usuarioDao)
        {
            var usuario = ConstruirUsuario(registro);
            var usuarioId = usuarioDao.CrearUsuario(usuario);
            var usuarioCreado = usuarioDao.BuscarPorId(usuarioId);

            return usuarioCreado;
        }

        private Perfil CrearPerfil(Usuario usuario, Registro registro, PerfilDao perfilDao)
        {
            var perfil = ConstruirPerfil(usuario.Id, registro);
            var perfilId = perfilDao.GuardarPerfil(perfil);
            var perfilCreado = perfilDao.BuscarPorId(perfilId);

            return perfilCreado;
        }
    }
}