
using System.Collections.Generic;

namespace IntegracionBancaria.Model.Domain.Mock
{
    public class Usuario
    {
        public string Usr { get; set; }
        public string Nombre { get; set; }
        public List<Banco> Bancos { get; set; }
    }
}