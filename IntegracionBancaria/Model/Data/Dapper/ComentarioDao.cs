

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Dapper;
using System.Data;

namespace IntegracionBancaria.Model.Data.Dapper
{
    public class ComentarioDao : BaseDao
    {
        public ComentarioDao(IOptions<AppSettings> appSettings, ILogger<ComentarioDao> logger) : base(appSettings, logger)
        {
        }

        public int CrearComentario(string nombre, string ip, string correo, string texto)
        {
            _logger.LogInformation("Agregando comentario de {1}", nombre);
            var filas = 0;

            using (IDbConnection db = GetConnection())
            {
                var sql = "insert into bancos.comentario (nombre, ip, correo, comentario) values (@Nombre, @Ip, @Correo, @Comentario) ";
                filas = db.Execute(sql, new { Nombre = nombre, Ip = ip, Correo = correo, Comentario = texto });
            }

            return filas;
        }
    }
}