namespace IntegracionBancaria.Domain
{
    public class Usuario
    {
        public long Id { get; set; }
        public string Usr { get; set; }
        public string Clave { get; set; }
        public bool Activo { get; set; }
    }
}