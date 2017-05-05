using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IntegracionBancaria.Model.Views
{
    public class RegistroViewModel
    {
        public List<SelectListItem> Bancos { get; set; }
        public Registro Registro { get; set; }
    }
}