using System;

namespace IntegracionBancaria.Model.Domain
{
    public class Documento
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public DateTime Emision { get; set; }
        public string Ubicacion { get; set; }
    }
}