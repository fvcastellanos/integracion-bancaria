
using System;
using System.Collections.Generic;
using IntegracionBancaria.Model.Data.Dapper;
using IntegracionBancaria.Model.Domain;
using IntegracionBancaria.Model.Views;
using Microsoft.Extensions.Logging;

namespace IntegracionBancaria.Service
{
    public class ServicioBanco
    {
        private BancoDao _bancoDao;
        private ILogger _logger;

        public ServicioBanco(ILogger<ServicioBanco> logger, BancoDao bancoDao)
        {
            _bancoDao = bancoDao;
            _logger = logger;
        }
        
        public Result<Exception, IList<Banco>> ObtenerBancosActivos()
        {
            try 
            {
                _logger.LogInformation("Obteniendo listado de bancos activos");
                var bancos = _bancoDao.ObtenerBancosActivos();
                return Result<Exception, IList<Banco>>.ForSuccess(bancos);
            }
            catch(Exception ex)
            {
                return Result<Exception, IList<Banco>>.ForFailure(ex);
            }
        }

        public Result<Exception, long> RegistrarUsuario(Registro registro)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                return Result<Exception, long>.ForFailure(ex);
            }
        }
    }
}