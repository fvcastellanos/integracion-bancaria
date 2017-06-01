
using System.Collections.Generic;

namespace IntegracionBancaria.Model.Domain.Mock
{
    public class Servicio
    {
        public long Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Moneda { get; set; }
        public float SaldoTotal { get; set; }        
    }
}