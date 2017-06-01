using System.Collections.Generic;
using IntegracionBancaria.Model.Domain;

namespace IntegracionBancaria.Model.Views
{
    public class ConsultaTarjetasViewModel
    {
        public IList<Banco> Bancos { get; set; }

        public IList<Cuenta> Tarjetas { get; set; }

        public string Codigo { get; set; }

        public string Numero { get; set; }

        public IList<IntegracionBancaria.Model.Domain.Mock.Tarjeta> SaldoTarjetas { get; set; }
    }
}