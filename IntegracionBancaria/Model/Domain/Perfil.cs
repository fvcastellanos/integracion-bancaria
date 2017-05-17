namespace IntegracionBancaria.Domain
{
    public class Perfil
    {
        public long Id { get; set; }
        public long UsuarioId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
    }
}