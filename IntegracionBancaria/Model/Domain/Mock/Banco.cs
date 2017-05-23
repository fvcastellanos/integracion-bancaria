
using System.Collections.Generic;

namespace IntegracionBancaria.Model.Domain.Mock
{
    public class Banco
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public List<Cuenta> Cuentas { get; set; }
    }
}