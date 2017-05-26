using System.Collections.Generic;
using IntegracionBancaria.Model.Domain;

namespace IntegracionBancaria.Model.Views
{
    public class EstadoCuentaViewModel
    {
        public IList<Banco> Bancos { get; set; }

        public string Codigo { get; set; }

        public IList<Cuenta> Cuentas { get; set; }

        public string Numero { get; set; }
    }
}
