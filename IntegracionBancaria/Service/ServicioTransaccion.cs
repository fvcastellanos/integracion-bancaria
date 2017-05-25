using IntegracionBancaria.Model.Data.Dapper;
using IntegracionBancaria.Model.Domain;
using Microsoft.Extensions.Logging;

namespace IntegracionBancaria.Service
{
    public class ServicioTransaccion
    {
        private readonly TransaccionDao _transaccionDao;
        private readonly ILogger _logger;

        public ServicioTransaccion(ILogger<ServicioTransaccion> logger, 
                                   TransaccionDao transaccionDao)
        {
            _transaccionDao = transaccionDao;
            _logger = logger;
        }
        
        public void CrearTransaccion(Transaccion transaccion)
        {
            _logger.LogInformation("Creando transaccion.");
            _transaccionDao.CrearTransaccion(transaccion);
        }
    }
}