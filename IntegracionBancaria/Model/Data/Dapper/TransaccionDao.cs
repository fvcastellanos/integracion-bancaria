using System.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Dapper;
using IntegracionBancaria.Model.Domain;

namespace IntegracionBancaria.Model.Data.Dapper
{
    public class TransaccionDao : BaseDao
    {
        public TransaccionDao(IOptions<AppSettings> appSettings, ILogger<UsuarioDao> logger) : base(appSettings, logger)
        {
        }

        public void CrearTransaccion(Transaccion transaccion)
        {
            using (IDbConnection db = GetConnection())
            {
                var sql = "INSERT INTO bancos.transaccion (operacion_id, usuario_id, banco_id, monto, descripcion, autorizacion) " +
                          "VALUES (@OperacionId, @UsuarioId, @BancoId, @Monto, @Descripcion, @Autorizacion) ";

                db.Execute(sql, new { OperacionId = transaccion.OperacionId, 
                                      UsuarioId = transaccion.UsuarioId, 
                                      BancoId = transaccion.BancoId, 
                                      Monto = transaccion.Monto, 
                                      Descripcion = transaccion.Descripcion, 
                                      Autorizacion = transaccion.Autorizacion 
                                    }
                            );
            }
        }
    }
}