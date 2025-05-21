
namespace Unigis.PuntoVentas.BackEnd.Data.Models
{
    public class VentasZona
    {
        public decimal Total { get; set; }
        public List<VentaDetalle> Detalle { get; set; } = new ();
    }

    public class VentaDetalle
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}