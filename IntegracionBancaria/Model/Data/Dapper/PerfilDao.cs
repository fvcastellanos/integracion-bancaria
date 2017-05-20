using System.Data;
using IntegracionBancaria.Domain;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Dapper;

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

                perfil = db.QuerySingle<Perfil>(sql, new { Id = id });
            }
        
            return perfil;
        }

    }
}