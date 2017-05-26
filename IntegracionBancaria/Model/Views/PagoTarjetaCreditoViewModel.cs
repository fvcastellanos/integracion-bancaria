using System;
using System.Collections.Generic;
using IntegracionBancaria.Model.Domain;

namespace IntegracionBancaria.Model.Views
{
    public class PagoTarjetaCreditoViewModel
    {
        public string Usuario { get; set; }
        public string Codigo { get; set; }
        public IEnumerable<Banco> Bancos { get; set; }
        public string  Autorizacion { get; set; }
    }

}