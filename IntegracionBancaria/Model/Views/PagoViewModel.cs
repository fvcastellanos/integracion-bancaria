using System;
using System.Collections.Generic;
using IntegracionBancaria.Model.Domain.Mock;
using IntegracionBancaria.Model.Domain;

namespace IntegracionBancaria.Model.Views
{
    public class PagoViewModel
    {
        public string Usuario { get; set; }
        public string Codigo { get; set; }
        public IEnumerable<Domain.Banco> Bancos { get; set; }
        public string  Autorizacion { get; set; }
        public IEnumerable<Servicio> Servicios { get; set; }
        public IEnumerable<TipoDocumento> TipoDocumentos { get; set; }
    }
}