using System.Data;
using IntegracionBancaria.Domain;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Dapper;
using System.Linq;

namespace IntegracionBancaria.Model.Data.Dapper
{
    public class PerfilDao : BaseDao
    {
        public PerfilDao(IOptions<AppSettings> appSettings, ILogger<PerfilDao> logger) : base(appSettings, logger)
        {
        }

        public long GuardarPerfil(Perfil perfil)
        {
            var sql = "insert into bancos.perfil (id, usuario_id, nombres, apellidos, correo) values " +
                 "(@Id, @UsuarioId, @Nombres, @Apellidos, @Correo)";
            
            long id;

            using (IDbConnection db = GetConnection())
            {
                id = GetNexSequenceNumber(db, "bancos.perfil_seq");

                _logger.LogInformation("Creando perfil nombre: {0}", perfil.Nombres);
                db.Execute(sql, new { Id = id, UsuarioId = perfil.UsuarioId, Nombres = perfil.Nombres, 
                    Apellidos = perfil.Apellidos, Correo = perfil.Correo });
            }

            return id;
        }

        public Perfil BuscarPorId(long id)
        {
            var sql = "select * from bancos.perfil where id = @Id";
            Perfil perfil = null;

            using (IDbConnection db = GetConnection())
            {
                _logger.LogInformation("Obteninedo perfil id: {0}", id);

                perfil = db.Query<Perfil>(sql, new { Id = id }).FirstOrDefault();
            }
        
            return perfil;
        }

        public Perfil BuscarPorUsuario(string usr)
        {
            var sql = "select * from bancos.perfil p " +
                "inner join bancos.usuario u on p.usuario_id = u.id " +
                "where u.usuario = @Usuario";

            Perfil perfil = null;
            
            using (IDbConnection db = GetConnection())
            {
                _logger.LogInformation("Buscando perfil del usuario: {0}", usr);
                perfil = db.Query<Perfil>(sql, new { Usuario = usr }).FirstOrDefault();
            }

            return perfil;
        }

    }
}