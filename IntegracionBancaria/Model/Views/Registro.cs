
using System.ComponentModel.DataAnnotations;

namespace IntegracionBancaria.Model.Views
{
    public class Registro
    {
        [Required]
        public long BancoId { get; set; }

        [Required]
        [StringLength(50)]
        public string Usuario { get; set; }

        [Required]
        [StringLength(150)]
        public string Clave { get; set; }

        [Required]
        [StringLength(150)]
        public string ConfirmacionClave { get; set; }
    }
}