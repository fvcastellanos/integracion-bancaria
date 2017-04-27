using System.ComponentModel.DataAnnotations;

namespace IntegracionBancaria.Model.Views
{
    public class Comentario
    {
        [Required]
        [StringLength(150)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(255)]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        public string Texto { get; set; }
    }
}