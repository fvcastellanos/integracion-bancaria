using System;

namespace IntegracionBancaria.Model.Domain
{
    public class Bitacora
    {
        public long Id { get; set; }
        public string Operacion { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
    }
}