
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
        [StringLength(50)]
        public string Clave { get; set; }

        [Required]
        [StringLength(50)]
        [Compare("Clave")]
        public string ConfirmacionClave { get; set; }

        [Required]
        [StringLength(150)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(150)]
        public string Apellidos { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Correo { get; set; }
    }
}