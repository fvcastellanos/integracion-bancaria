
using System.Collections.Generic;

namespace IntegracionBancaria.Model.Domain.Mock
{
    public class Banco
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public List<Cuenta> Cuentas { get; set; }
    }
}