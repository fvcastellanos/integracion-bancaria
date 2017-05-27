
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using IntegracionBancaria.Model.Domain;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace IntegracionBancaria.Model.Data.Dapper
{
    public class BancoDao : BaseDao
    {
        public BancoDao(IOptions<AppSettings> appSettings, ILogger<BancoDao> logger) : base(appSettings, logger)
        {
        }

        public IList<Banco> ObtenerBancosActivos()
        {
            IList<Banco> bancos = null;
            using (IDbConnection conexion = GetConnection())
            {
                var consulta = "select * from bancos.banco where activo = true";
                bancos = conexion.Query<Banco>(consulta).AsList();
            }

            return bancos;
        }

        public IList<Banco> ObtenerBancosPorUsuario(string usuario)
        {
            IList<Banco> bancos = null;
            using (IDbConnection conexion = GetConnection())
            {
                var consulta = "select b.* " +
                    "from bancos.usuario u " +
                    "  inner join bancos.usuario_banco ub on u.id = ub.usuario_id " +
                    "  inner join bancos.banco b on ub.banco_id = b.id " +
                    "  where usuario = @Usuario and b.activo = true and u.activo = true";

                bancos = conexion.Query<Banco>(consulta, new { Usuario = usuario }).AsList();
            }

            return bancos;
        }

        public Banco ObtenerBancoPorCodigo(string codigo)
        {
            Banco banco = null;

            using (IDbConnection db = GetConnection())
            {
                var sql = "select * from bancos.banco where codigo = @Codigo";

                banco = db.Query<Banco>(sql, new { Codigo = codigo }).FirstOrDefault();
            }

            return banco;
        }
    }
}