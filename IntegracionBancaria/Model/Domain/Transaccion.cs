
using System;

namespace IntegracionBancaria.Model.Domain
{
    public class Transaccion
    {
        public long Id { get; }
        public long OperacionId { get; }
        public long UsuarioId { get; }
        public DateTime Fecha { get; }
        public string Descripcion { get; }
        
        public Transaccion(long operacionId,
                           long usuarioId,
                           string descripcion)
        {
            OperacionId = operacionId;
            UsuarioId = usuarioId;
            Descripcion = descripcion;
        }
    }
}