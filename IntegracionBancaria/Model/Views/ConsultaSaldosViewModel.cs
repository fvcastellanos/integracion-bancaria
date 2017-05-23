using System;
using System.Collections.Generic;
using IntegracionBancaria.Model.Domain;

namespace IntegracionBancaria.Model.Views
{
    public class ConsultaSaldosViewModel
    {
        public long BancoId { get; set; }
        public IEnumerable<Banco> Bancos { get; set; }
        public DateTime DeFecha { get; set; }
        public DateTime AFecha { get; set; }
    }

}