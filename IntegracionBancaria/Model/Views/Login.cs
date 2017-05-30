using System.ComponentModel.DataAnnotations;

namespace IntegracionBancaria.Model.Views
{
    public class Login
    {
        [Required]
        public string Usuario { get; set; }

        [Required]
        public string Clave { get; set; }
    }
}