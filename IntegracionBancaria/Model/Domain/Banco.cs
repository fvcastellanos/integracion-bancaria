
namespace IntegracionBancaria.Model.Domain
{
    public class Banco
    {
        public long Id { get; set; }

        public string Codigo { get; set; }

        public string Nombre { get; set; }

        public string Pais { get; set; }

        public bool Activo { get; set; }
    }
}