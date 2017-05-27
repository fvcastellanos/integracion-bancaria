using System;

namespace IntegracionBancaria.Model.Domain.Mock
{
    public class Prestamo
    {
        public string NumeroPrestamo { get; set; }
        public string NombreCuenta { get; set; }
        public string Moneda { get; set; }
        public float SaldoDisponible { get; set; }
        public float SaldoEnReserva { get; set; }
        public float SaldoFlotante { get; set; }
        public float SaldoTotal { get; set; }
    }

}