
namespace IntegracionBancaria.Model.Domain
{
    public class TipoCambio
    {
        public string Nombre { get; }
        public double ValorCompra { get; }
        public double ValorVenta { get; }
        public string CodigoIso { get; }

        public TipoCambio(string nombre, double valorCompra, double valorVenta, string codigoIso)
        {
            Nombre = nombre;
            ValorCompra = valorCompra;
            ValorVenta = valorVenta;
            CodigoIso = codigoIso;
        }
    }
}