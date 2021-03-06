using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IntegracionBancaria.Model.Domain;

namespace IntegracionBancaria.Model.Views
{
    public class EstadoCuentaViewModel
    {
        public IList<Banco> Bancos { get; set; }

        public IList<Cuenta> Cuentas { get; set; }

        public IList<Movimiento> Movimientos { get; set; }

        [Required]
        [MinLength(1)]
        public string Codigo { get; set; }

        [Required]
        [MinLength(1)]
        public string Numero { get; set; }
    }
}
