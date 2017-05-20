using System.Data;
using IntegracionBancaria.Domain;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Dapper;

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
                    "(@Id, @Usuario, @Clave, 'S')";

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

    }
}