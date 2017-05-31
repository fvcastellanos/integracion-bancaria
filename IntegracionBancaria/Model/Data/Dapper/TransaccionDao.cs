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

        public long CrearTransaccion(Transaccion transaccion)
        {
            long id;
            using (IDbConnection db = GetConnection())
            {
                var sql = "INSERT INTO bancos.transaccion (id, operacion_id, usuario_id, descripcion) " +
                          "VALUES (@Id, @OperacionId, @UsuarioId, @Descripcion) ";

                id = GetNexSequenceNumber(db, "bancos.transaccion_seq");

                db.Execute(sql, new { Id = id,
                                      OperacionId = transaccion.OperacionId, 
                                      UsuarioId = transaccion.UsuarioId, 
                                      Descripcion = transaccion.Descripcion
                                    }
                            );
            }
            return id;
        }

        public long CrearTransaccionDetalle(TransaccionDetalle transaccionDetalle)
        {
            long id;
            using (IDbConnection db = GetConnection())
            {
                var sql = "INSERT INTO bancos.transaccion_detalle (id, transaccion_id, a_banco_id, a_cuenta, de_banco_id, de_cuenta, moneda, monto, autorizacion) " +
                          "VALUES (@Id, @TransaccionId, @ABancoId, @ACuenta, @DeBancoId, @DeCuenta, @Moneda, @Monto, @Autorizacion) ";

                id = GetNexSequenceNumber(db, "bancos.transaccion_detalle_id_seq");

                db.Execute(sql, new { 
                                        Id = id,
                                        TransaccionId = transaccionDetalle.TransaccionId,
                                        ABancoId = transaccionDetalle.ABancoId,
                                        ACuenta = transaccionDetalle.ACuenta,
                                        DeBancoId = transaccionDetalle.DeBancoId,
                                        DeCuenta = transaccionDetalle.DeCuenta,
                                        Moneda = transaccionDetalle.Moneda,
                                        Monto = transaccionDetalle.Monto,
                                        Autorizacion = transaccionDetalle.Autorizacion                    
                                    }
                            );
            }
            return id;
        }
    }
}