using System.Data;
using IntegracionBancaria.Domain;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Dapper;
using System.Linq;

namespace IntegracionBancaria.Model.Data.Dapper
{
    public class UsuarioDao : BaseDao
    {
        public UsuarioDao(IOptions<AppSettings> appSettings, ILogger<UsuarioDao> logger) : base(appSettings, logger)
        {
        }

        public long CrearUsuario(Usuario usuario)
        {
            long id = 0;

            using (IDbConnection db = GetConnection())
            {
                var sql = "insert into usuario (id, usuario, clave, activo) values " +
                    "(@Id, @Usuario, @Clave, true)";

                id = GetNexSequenceNumber(db, "bancos.usuario_seq");
                db.Execute(sql, new { Id = id, Usuario = usuario.Usr, Clave = usuario.Clave });
            }

            return id;
        }

        public long AsociarBancoUsuario(long bancoId, long usuarioId, string autorizacion)
        {
            long id = 0;

            using (IDbConnection db = GetConnection())
            {
                var sql = "insert into usuario_banco (id, banco_id, usuario_id, autorizacion) values " +
                    "(@Id, @BancoId, @UsuarioId, @Autorizacion)";
                
                id = GetNexSequenceNumber(db, "bancos.usuario_banco_seq");
                db.Execute(sql, new { @Id = id, @BancoId = bancoId, @UsuarioId = usuarioId, @Autorizacion = autorizacion });
            }

            return id;
        }

        public Usuario BuscarPorId(long id)
        {
            Usuario usuario = null;
            
            using (IDbConnection db = GetConnection())
            {
                var sql = "select * from bancos.usuario where id = @Id";

                usuario = db.Query<Usuario>(sql, new { Id = id }).FirstOrDefault();
            }

            return usuario;
        }

        public Usuario BuscarPorUsuario(string usr)
        {
            Usuario usuario = null;

            using (IDbConnection db = GetConnection())
            {
                var sql = "select id, usuario as usr, clave, activo from bancos.usuario where usuario = @Usuario";

                usuario = db.Query<Usuario>(sql, new { Usuario = usr }).FirstOrDefault();
            }

            return usuario;
        }

    }
}