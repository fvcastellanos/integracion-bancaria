using System.Collections.Generic;
using IntegracionBancaria.Domain;
using IntegracionBancaria.Model.Domain;

namespace IntegracionBancaria.Model.Views
{
    public class AgregarBancoViewModel
    {
        public IList<Banco> Bancos { get; set; }
        public IList<Banco> BancosSuscritos { get; set; }
        public Perfil PerfilUsuario { get; set; }
        public string Codigo { get; set; }
    }
}