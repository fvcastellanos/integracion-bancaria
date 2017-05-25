
using System;

namespace IntegracionBancaria.Model.Domain
{
    public class Transaccion
    {
        public long Id { get; }
        public long OperacionId { get; }
        public long UsuarioId { get; }
        public long BancoId { get; }
        public DateTime Fecha { get; }
        public double Monto { get; }
        public string Descripcion { get; }
        public string Autorizacion { get; }
        
        public Transaccion(long operacionId,
                           long usuarioId,
                           long bancoId,
                           double monto,
                           string descripcion,
                           string autorizacion)
        {
            OperacionId = operacionId;
            UsuarioId = usuarioId;
            BancoId = bancoId;
            Monto = monto;
            Descripcion = descripcion;
            Autorizacion = autorizacion;
        }
    }
}