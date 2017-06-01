using System.Collections.Generic;
using Dapper;
using IntegracionBancaria.Model.Domain;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace IntegracionBancaria.Model.Data.Dapper
{
    public class BitacoraDao : BaseDao
    {
        public BitacoraDao(IOptions<AppSettings> appSettings, ILogger<BitacoraDao> logger) : base(appSettings, logger)
        {
        }

        public IList<Bitacora> ObtenerBitacoraUsuario(string usuario)
        {
            IList<Bitacora> bitacoras = null;
            using (var db = GetConnection())
            {
                var sql = "select t.id, o.nombre operacion, u.usuario, t.fecha, t.descripcion " +
                    "from bancos.transaccion t " +
                    " inner join bancos.operacion o on t.operacion_id = o.id " +
                    " inner join bancos.usuario u on t.usuario_id = u.id " +
                    " where u.usuario = @Usuario";

                bitacoras = db.Query<Bitacora>(sql, new { Usuario = usuario}).AsList();
            }

            return bitacoras;
        }
    }
}