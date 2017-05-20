
using System;
using IntegracionBancaria.Model.Data.Dapper;
using IntegracionBancaria.Model.Domain;

namespace IntegracionBancaria.Service
{
    public class ServicioComentario
    {
        private readonly ComentarioDao _comentarioDao;

        public ServicioComentario(ComentarioDao comentarioDao)
        {
            _comentarioDao = comentarioDao;
        }
        public Result<Exception, int> GuardarComentario(string nombre, string ip, string correo, string comentario)
        {
            try
            {
            var filas = _comentarioDao.CrearComentario(nombre, ip, correo, comentario);
            return Result<Exception, int>.ForSuccess(filas);

            }
            catch (Exception ex)
            {
                return Result<Exception, int>.ForFailure(ex);
            }
        }
    }
}