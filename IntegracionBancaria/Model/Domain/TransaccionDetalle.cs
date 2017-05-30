
using System;

namespace IntegracionBancaria.Model.Domain
{
    public class TransaccionDetalle
    {
        public long Id { get; }
        public long TransaccionId { get; }
        public long ABancoId { get; }
        public string ACuenta { get; }
        public long DeBancoId { get; }
        public string DeCuenta { get; }
        public string Moneda { get; }
        public double Monto { get; }
        public string Autorizacion { get; }
        public TransaccionDetalle(long transaccionId,
                                  long aBancoId,
                                  string aCuenta,
                                  long deBancoId,
                                  string deCuenta,
                                  string moneda,
                                  double monto,
                                  string autorizacion)
        {
            TransaccionId = transaccionId;
            ABancoId = aBancoId;
            ACuenta = aCuenta;
            DeBancoId = deBancoId;
            DeCuenta = deCuenta;
            Moneda = moneda;
            Monto = monto;
            Autorizacion = autorizacion;
        }
    }
}