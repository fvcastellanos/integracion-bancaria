using System;
namespace IntegracionBancaria.Model.Domain
{
    public class Movimiento
    {
      public DateTime Fecha { get; set; }
      public string Numero { get; set; }
      public string Moneda { get; set; }
      public string Documento { get; set; }
      public double Debito { get; set; }
      public double Credito { get; set; }

    }
}
