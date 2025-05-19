using Unigis.PuntoVentas.BackEnd.Data.Entidades;

namespace Unigis.PuntoVentas.BackEnd.Data.DTOs
{
    public class PuntoDeVentasDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public decimal Ventas { get; set; }
        public Zonas Zona { get; set; }
    }
}